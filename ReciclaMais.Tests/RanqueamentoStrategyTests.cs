using ReciclaMais.Services;
using ReciclaMais.Models;
using Xunit;
using System.Collections.Generic;

public class RanqueamentoStrategyTests
{
    [Fact]
    public void DeveRanquearPorQuantidadeMateriais()
    {
        var contribuintes = new List<Contribuinte>
        {
            new Contribuinte { Nome = "Contribuinte 1", Materiais = new List<Material> { new Material(), new Material() } },
            new Contribuinte { Nome = "Contribuinte 2", Materiais = new List<Material> { new Material() } }
        };

        var strategy = new RanqueamentoPorQuantidade();
        var ranqueados = strategy.Ranquear(contribuintes);

        Assert.Equal("Contribuinte 1", ranqueados[0].Nome);
    }

    [Fact]
    public void DeveRanquearPorPesoMateriais()
    {
        var contribuintes = new List<Contribuinte>
        {
            new Contribuinte { Nome = "Contribuinte 1", Materiais = new List<Material> { new Material { PesoAproximado = 5 }, new Material { PesoAproximado = 3 } } },
            new Contribuinte { Nome = "Contribuinte 2", Materiais = new List<Material> { new Material { PesoAproximado = 10 } } }
        };

        var strategy = new RanqueamentoPorPeso();
        var ranqueados = strategy.Ranquear(contribuintes);

        Assert.Equal("Contribuinte 2", ranqueados[0].Nome);
    }
}
