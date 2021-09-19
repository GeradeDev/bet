export class SessionUser {
    userID: number;
    sessionToken: string;
    firstname: string;
    surname: string;
    serviceProvider:string;
    roles: string[];
    passwordChangeRequired: boolean;
    endPointAddress:string;
    serviceProviderID: number;
    initialLogin:InitialLogin;
  }

export class InitialLogin{
    roles: string[];
    serviceProviderID: number;
    serviceProvider: string;
    isInitialLogIn:boolean;
  }