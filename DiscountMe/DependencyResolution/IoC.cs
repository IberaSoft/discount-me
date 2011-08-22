using StructureMap;
namespace DiscountMe {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x => x.Scan(scan =>
                                                 {
                                                     scan.TheCallingAssembly();
                                                     scan.WithDefaultConventions();
                                                     scan.LookForRegistries();
                                                 }));
            return ObjectFactory.Container;
        }
    }
}