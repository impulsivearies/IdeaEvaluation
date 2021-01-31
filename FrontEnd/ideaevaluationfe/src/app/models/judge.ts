import { Idea } from "./idea";

export class Judge{
     name:string;
     emailid:string;
     judgeid:number;
     assignedIdeas: Idea[];
    
    constructor(name : string, emailid : string, judgeid : number, ideas : Idea[]){
        this.emailid = emailid;
        this.name = name;
        this.judgeid = judgeid;
        this.assignedIdeas = ideas;
    }
}