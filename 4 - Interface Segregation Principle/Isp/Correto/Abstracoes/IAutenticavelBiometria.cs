namespace Isp.Correto.Abstracoes;

public interface IAutenticavelBiometria
{
    bool ValidarBiometria(byte[] dadosBiometricos);
}