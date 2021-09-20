using BestShop.Api.Authentication;
using BestShop.Api.DAL;
using BestShop.Api.DTO;
using BestShop.Api.Models;
using BetShop.Common.Mailer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BestShop.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : BaseController
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private IMailSender _mailSender { get; set; }

        GenericRepository<Product> _prodsRepo { get; set; }
        GenericRepository<Order> _orderRepo { get; set; }
        GenericRepository<OrderLine> _orderLinesRepo { get; set; }

        public CheckoutController(IUnitOfWork unitOfWork, IMailSender mailSender)
        {
            _unitOfWork = unitOfWork;
            _mailSender = mailSender;

            _prodsRepo = _unitOfWork.GetRepository<GenericRepository<Product>>();
            _orderRepo = _unitOfWork.GetRepository<GenericRepository<Order>>();
            _orderLinesRepo = _unitOfWork.GetRepository<GenericRepository<OrderLine>>();
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateOrder([FromBody] ShoppingCart shoppingcart)
        {
            try
            {
                string newOrderNo = $"ORD{(_orderRepo.Get().ToList().Count + 1).ToString().PadLeft(5, '0')}";

                Order newOrder = new Order(Guid.NewGuid());
                newOrder.UserId = GetUserId();
                newOrder.OrderNo = newOrderNo;
                newOrder.OrderTotal = (decimal)shoppingcart.CartTotal;

                _orderRepo.Insert(newOrder);

                foreach (CartItem ci in shoppingcart.Items)
                {
                    OrderLine newLine = new OrderLine(Guid.NewGuid());
                    newLine.OrderId = newOrder.Id;
                    newLine.LineTotal = (decimal)(ci.Price * ci.Quantity);
                    newLine.ProductId = ci.Id;
                    newLine.Quantity = ci.Quantity;

                    _orderLinesRepo.Insert(newLine);
                }

                _unitOfWork.Save();

                var emailTemplate = _mailSender.LoadTemplate("OrderPlacedEmailTemplate.html");

                StringBuilder rows = new StringBuilder();

                shoppingcart.Items.ForEach(i =>
                {
                    rows.AppendLine($@"<tr class='process-tbl-td'><td>{i.Name}</td><td>{i.Quantity}</td><td>{i.Price}</td><td>{(i.Price * i.Quantity)}</td></tr>");
                });
                
                rows.AppendLine($@"<tr class='process-tbl-td'><td colspan=""3""></td><td class=""total-col"">R {shoppingcart.CartTotal}</td></tr>");

                emailTemplate = emailTemplate.Replace("##OrderLines##", rows.ToString());
                _mailSender.AddRecipient(GetUserEmail());
                _mailSender.AddSubject($"Order Placed: {newOrder.OrderNo}");
                _mailSender.AddBody(emailTemplate, true);

                _mailSender.SendMail();

                return Ok($"Order {newOrderNo} was successfully placed.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occured trying to load all products. {ex.Message}");
            }
        }
    }
}
