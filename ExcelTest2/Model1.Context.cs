﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExcelTest2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PerDiemAmountsEntities : DbContext
    {
        public PerDiemAmountsEntities()
            : base("name=PerDiemAmountsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AprPerDiem> AprPerDiems { get; set; }
        public virtual DbSet<AugPerDiem> AugPerDiems { get; set; }
        public virtual DbSet<CityPerDiem> CityPerDiems { get; set; }
        public virtual DbSet<DecPerDiem> DecPerDiems { get; set; }
        public virtual DbSet<FebPerDiem> FebPerDiems { get; set; }
        public virtual DbSet<JanPerDiem> JanPerDiems { get; set; }
        public virtual DbSet<JulPerDiem> JulPerDiems { get; set; }
        public virtual DbSet<JunPerDiem> JunPerDiems { get; set; }
        public virtual DbSet<MarPerDiem> MarPerDiems { get; set; }
        public virtual DbSet<MayPerDiem> MayPerDiems { get; set; }
        public virtual DbSet<NovPerDiem> NovPerDiems { get; set; }
        public virtual DbSet<OctPerDiem> OctPerDiems { get; set; }
        public virtual DbSet<SepPerDiem> SepPerDiems { get; set; }
        public virtual DbSet<YearPerDiem> YearPerDiems { get; set; }
    }
}
