using ReciclaMais.Models;
using System;
using Xunit;

public class UsuarioFactoryTests
{
    [Fact]
    public void DeveCriarContribuinte()
    {
        var usuario = UsuarioFactory.CriarUsuario("Contribuinte");

        Assert.IsType<Contribuinte>(usuario);
    }

    [Fact]
    public void DeveCriarColetor()
    {
        var usuario = UsuarioFactory.CriarUsuario("Coletor");

        Assert.IsType<Coletor>(usuario);
    }

    [Fact]
    public void DeveLancarExcecaoParaTipoInvalido()
    {
        Assert.Throws<ArgumentException>(() => UsuarioFactory.CriarUsuario("Invalido"));
    }
}
