namespace Logica.Mediatr;

public abstract class Mediator
{
    public abstract void Send(Colleague colleague);
}
public abstract class Colleague
{
    protected Mediator mediator;

    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }

    public virtual void Send(string message)
    {
        mediator.Send(this);
    }
    public abstract void Notify();
}
// класс заказчика

class ManagerMediator : Mediator
{
    public Colleague Customer { get; set; }
    public Colleague Programmer { get; set; }
    public Colleague Tester { get; set; }
    public override void Send(Colleague colleague)
    {
        // если отправитель - заказчик, значит есть новый заказ
        // отправляем сообщение программисту - выполнить заказ
        if (Customer == colleague)
            Programmer.Notify();
        // если отправитель - программист, то можно приступать к тестированию
        // отправляем сообщение тестеру
        else if (Programmer == colleague)
            Tester.Notify();
        // если отправитель - тест, значит продукт готов
        // отправляем сообщение заказчику
        else if (Tester == colleague)
            Customer.Notify();
    }
}