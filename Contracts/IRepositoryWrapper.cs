namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IDeviceRepository Device { get; }
        IEnvidataRepository Envidata { get; }
        IVariableRepository Variable { get; }
        IModuleRepository Module { get; }
        IModuletypeRepository Moduletype { get; }
        IMakerRepository Maker { get; }
        void Save();
    }
}
