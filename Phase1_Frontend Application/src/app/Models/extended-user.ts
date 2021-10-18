import { User } from "./user";

export class ExtendedUser extends User{
    IsUserActive:boolean=false;
    constructor()
    {
        super();
        this.IsUserActive=false;
    }
}