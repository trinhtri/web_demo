namespace DGod.SuparCar.Result;

public interface IResult
{
    string Message { get; set; }

    bool Succeeded { get; set; }
}