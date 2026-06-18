using StockportGovUK.NetStandard.Gateways.Netcall;

public interface IGatewayFactory
{
    T Create<T>(string clientName) where T : class;
}