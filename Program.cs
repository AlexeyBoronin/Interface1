
/*Human h = new Human();
Car car = new Car();
DoAction(car);
DoAction(h);

Message hello = new Message("hello world");
hello.Print();
BaseAction baseAction = new BaseAction();
//baseAction.Move();

((IAction)baseAction).Move();
if(baseAction is IAction action)action.Move();
IAction baseAction1= new BaseAction();
baseAction1.Move();

void DoAction(IMovable movable) => movable.Move();
interface IMovable {
    //{
    //    public const int minSpeed = 0;

    //    private static int maxSpeed = 60;

    //    static double GetTime(double distance, double speed) => distance / speed;
    //    static int MaxSpeed
    //    {
    //        get => maxSpeed;
    //        set
    //        {
    //            if(value>0) maxSpeed = value;
    //        }
    //    }
    void Move()
    {
        Console.WriteLine("Walking");
    }
    //protected internal string Name { set; get; }

    //delegate void MoveHandler(string messange);

    //event MoveHandler MoveEvent;
}
interface IMessage
{
    string Text { set; get; }
}
interface IPrintable
{
    void Print();
}
interface IAction
{
    void Move();
}
class BaseAction : IAction
{
    void IAction.Move() => Console.WriteLine("Move in Base Class");
}

class Message :IMessage,IPrintable
{
    public string Text { set; get; }
    public Message(string text)=>Text = text;
    public void Print() => Console.WriteLine(Text);
}

class Human :IMovable
{
    public void Move()
    { Console.WriteLine("Человек движется!!!"); }
}
class Car:IMovable
{
    public void Move()
    { Console.WriteLine("Авто едет"); }
}*/

IMovable ted = new Human("Ted");
ted.MoveEvent += () => Console.WriteLine($"{ted.Name} is moving");
ted.Move();



interface IMovable
{
    protected internal void Move();
    protected internal string Name { get; }
    delegate void MoveHandler();
    protected internal event MoveHandler MoveEvent;
}
class Human:IMovable
{
    string name;
    IMovable.MoveHandler? moveEvent;
    event IMovable.MoveHandler IMovable.MoveEvent
    {
        add => moveEvent += value;//aasddasdsad
        remove=>moveEvent-=value;
    }

    string IMovable.Name { get => name;}
    public Human(string name)=>this.name = name;
    void IMovable.Move()
    {
        Console.WriteLine($"{name} is walking");
        moveEvent?.Invoke();
    }
}
