using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Entities;

public class Blog : BaseEntity
{
    public required string Name { get; set; }
    public required string Url { get; set; }
    public DateTime Created { get; set; }
}
