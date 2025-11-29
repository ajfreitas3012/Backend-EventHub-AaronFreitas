using UsersService.Domain;

namespace UsersService.Application;

public class GetUserActivityHistory
{
    // En esta primera entrega lo dejamos como stub.
    // Más adelante se conectará con Reservas y Pagos.
    public IEnumerable<string> Execute(Guid userId)
    {
        return new List<string>
        {
            "Reserva creada",
            "Pago confirmado",
            "Evento asistido"
        };
    }
}
