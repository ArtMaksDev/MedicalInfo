using MedicalInfo.App.Exceptions;

namespace MedicalInfo.Infrastructure.Exceptions.Sorting;

public class NotValidSortFieldException : ClientException
{
    private readonly string _field;

    public NotValidSortFieldException(string field)
    {
        _field = field;
    }

    public override string Message => $"Невалидное поле сортировки {_field}";
}