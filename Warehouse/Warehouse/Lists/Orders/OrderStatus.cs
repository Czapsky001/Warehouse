using System.ComponentModel.DataAnnotations;

namespace Warehouse.Lists.Orders;

public enum OrderStatus
{
    [EnumDataType(typeof(string))]
    New,
    Approve,
    Reject
}
