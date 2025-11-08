using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Features;

internal class SwitchPatternMatchCall : IFeature
{
    static readonly Guid empty = Guid.Empty;
    public void Action()
    {
        var typeParam = new Transaction
        {
            TransactionId = Guid.NewGuid(),
            ItemType = TransactionType.OffParking,
        };

        bool success = typeParam switch
        {
            { ItemType: TransactionType.OffParking or TransactionType.OnParking } => Mode(0),
            { Price: > 0 and < 10.000 } => Mode(1),
            { Price: > 10.000 } => Mode(2),
            _ => Mode(-1),
        };
    }

    internal bool Mode(int p)
    {
        return true;
    }
}


internal class Transaction
{
    public Guid TransactionId { get; set; }
    public TransactionType ItemType { get; set; }
    public double Price { get; set; }
}

enum TransactionType
{
    None,
    OffParking,
    OnParking,
    Vignette,
    RfidToken
}
