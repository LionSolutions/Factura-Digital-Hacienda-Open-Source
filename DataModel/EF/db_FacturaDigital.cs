namespace DataModel.EF
{
    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Linq;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class db_FacturaDigital : DbContext
    {
  

        //muy importante para poder crear migraciones nuevas en desarrollo incluir : base("name=db_FacturaDigital")
        //mientras q para el release o puesta a correr es :base(new ConnectionSettings().GetConnectionString())
        public db_FacturaDigital()
            //: base("name=db_FacturaDigital")
            :base(new ConnectionSettings().GetConnectionString())
        {
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<db_FacturaDigital>(null);
        }

    

        public virtual DbSet<Contribuyente> Contribuyente { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Factura_Detalle> Factura_Detalle { get; set; }
        public virtual DbSet<Factura_Detalle_Impuesto> Factura_Detalle_Impuesto { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Producto_Impuesto> Producto_Impuesto { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<SMTP> SMTP { get; set; }
        public virtual DbSet<Ubicacion> Ubicaciones { get; set; }
        public virtual DbSet<Contribuyente_Consecutivos> Contribuyente_Consecutivos { set; get; }
        public virtual DbSet<Errores_Sistema> Errores_Sistema { set; get; }

        public virtual DbSet<Factura_Resolucion> Factura_Resolucion { set; get; }
        public virtual DbSet<Factura_Resolucion_Detalle> Factura_Resolucion_Detalle { set; get; }
        public virtual DbSet<Factura_Resolucion_Detalle_Impuesto> Factura_Resolucion_Detalle_Impuesto { set; get; }        
        public virtual DbSet<Contribuyente_ActividadesEconomicas> Contribuyente_ActividadesEconomicas { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
             .HasMany(e => e.Producto_Impuesto)
             .WithRequired(e => e.Producto)
             .WillCascadeOnDelete(true);


            modelBuilder.Entity<Factura>()
             .HasMany(e => e.Factura_Detalle)
             .WithRequired(e => e.Factura)
             .WillCascadeOnDelete(true);

            modelBuilder.Entity<Factura_Detalle>()
             .HasMany(e => e.Factura_Detalle_Impuesto)
             .WithRequired(e => e.Factura_Detalle)
             .WillCascadeOnDelete(true);


            modelBuilder.Entity<Factura_Resolucion>()
           .HasMany(e => e.Factura_Resolucion_Detalle)
           .WithRequired(e => e.Factura_Resolucion)
           .WillCascadeOnDelete(true);

            modelBuilder.Entity<Factura_Resolucion_Detalle>()
            .HasMany(e => e.Factura_Resolucion_Detalle_Impuesto)
            .WithRequired(e => e.Factura_Resolucion_Detalle)
            .WillCascadeOnDelete(true);
        }
    }

   
       

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}