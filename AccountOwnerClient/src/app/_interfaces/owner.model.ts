import { Account } from "./accounts.model";

export interface Owner{
    id: string;
    name: string;
    dateOfBirth: Date;
    address: string;

    accounts?: Account[]; //Optional property property?
}