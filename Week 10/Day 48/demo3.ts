class Employee{
    public  id :number;
    protected name :string;
    private _salary :number;
    constructor(id:number,name:string,salary:number){
        this.id =id;
        this.name=name;
        this._salary=salary;


    }
    get  Salary(){
        return this._salary;
    }
    set Salary(value:number){
        if(value > 0){
            this._salary =value;

        }
    }
    displayDeatails(){
    console.log(`ID: ${this.id}, Name: ${this.name}, Salary: ${this._salary}`);}


}
class Manger extends Employee{
    public teamsize:Number;
    constructor(id:number,name:string,salary:number,teamsize:Number){
        super(id,name,salary);
        this.teamsize = teamsize;
    }

}
const emp = new Employee(1,"John Doe",50000);
// emp.Salary = 50000;
emp.displayDeatails();
const manager = new Manger(2,"Jane Smith",80000,5);
manager.displayDeatails();