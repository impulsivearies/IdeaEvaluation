export class Idea{
    ideaId:number;
    ideaName:string;
    ideaDescription:string;
    evaluatedCount:number;

    constructor(ideaId: number, ideaName: string, description: string, count: number){
        this.ideaId = ideaId;
        this.ideaName = ideaName;
        this.ideaDescription = description;
        this.evaluatedCount = count;
    }
}