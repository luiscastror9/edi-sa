﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNV_Site.Areas.BackOffice
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EntitiesBO : DbContext
    {
        public EntitiesBO()
            : base("name=EntitiesBO")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategoriasNotes> CategoriasNotes { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<SettingsIntegrationNotes> SettingsIntegrationNotes { get; set; }
        public virtual DbSet<ImagesSliderNotes> ImagesSliderNotes { get; set; }
        public virtual DbSet<SliderHome> SliderHome { get; set; }
        public virtual DbSet<Consultas> Consultas { get; set; }
        public virtual DbSet<RespuestaConsultas> RespuestaConsultas { get; set; }
        public virtual DbSet<SliderNotes> SliderNotes { get; set; }
    
        public virtual int sp_Delete_CategoriasNotes_id(Nullable<int> idCategoriasNotes, string descCategoriasNotes)
        {
            var idCategoriasNotesParameter = idCategoriasNotes.HasValue ?
                new ObjectParameter("IdCategoriasNotes", idCategoriasNotes) :
                new ObjectParameter("IdCategoriasNotes", typeof(int));
    
            var descCategoriasNotesParameter = descCategoriasNotes != null ?
                new ObjectParameter("descCategoriasNotes", descCategoriasNotes) :
                new ObjectParameter("descCategoriasNotes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Delete_CategoriasNotes_id", idCategoriasNotesParameter, descCategoriasNotesParameter);
        }
    
        public virtual int sp_Delete_Consultas_id(Nullable<int> idConsulta)
        {
            var idConsultaParameter = idConsulta.HasValue ?
                new ObjectParameter("IdConsulta", idConsulta) :
                new ObjectParameter("IdConsulta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Delete_Consultas_id", idConsultaParameter);
        }
    
        public virtual int sp_Delete_ImagesSliderNotes_id(Nullable<int> idImagesSliderNotes)
        {
            var idImagesSliderNotesParameter = idImagesSliderNotes.HasValue ?
                new ObjectParameter("IdImagesSliderNotes", idImagesSliderNotes) :
                new ObjectParameter("IdImagesSliderNotes", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Delete_ImagesSliderNotes_id", idImagesSliderNotesParameter);
        }
    
        public virtual int sp_Delete_Notes_id(Nullable<int> idNote)
        {
            var idNoteParameter = idNote.HasValue ?
                new ObjectParameter("IdNote", idNote) :
                new ObjectParameter("IdNote", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Delete_Notes_id", idNoteParameter);
        }
    
        public virtual int sp_Delete_RespuestaConsultas_id(Nullable<int> idRespuestaConsultas)
        {
            var idRespuestaConsultasParameter = idRespuestaConsultas.HasValue ?
                new ObjectParameter("IdRespuestaConsultas", idRespuestaConsultas) :
                new ObjectParameter("IdRespuestaConsultas", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Delete_RespuestaConsultas_id", idRespuestaConsultasParameter);
        }
    
        public virtual int sp_Delete_SettingsIntegrationNotes_id(Nullable<int> idSettingsIntegrationNotes)
        {
            var idSettingsIntegrationNotesParameter = idSettingsIntegrationNotes.HasValue ?
                new ObjectParameter("IdSettingsIntegrationNotes", idSettingsIntegrationNotes) :
                new ObjectParameter("IdSettingsIntegrationNotes", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Delete_SettingsIntegrationNotes_id", idSettingsIntegrationNotesParameter);
        }
    
        public virtual int sp_Delete_SliderHome_id(Nullable<int> idSliderHome)
        {
            var idSliderHomeParameter = idSliderHome.HasValue ?
                new ObjectParameter("IdSliderHome", idSliderHome) :
                new ObjectParameter("IdSliderHome", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Delete_SliderHome_id", idSliderHomeParameter);
        }
    
        public virtual int sp_Delete_SliderNotes_id(Nullable<int> idCategoriasNotes)
        {
            var idCategoriasNotesParameter = idCategoriasNotes.HasValue ?
                new ObjectParameter("IdCategoriasNotes", idCategoriasNotes) :
                new ObjectParameter("IdCategoriasNotes", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Delete_SliderNotes_id", idCategoriasNotesParameter);
        }
    
        public virtual int sp_Insert_CategoriasNotes(string descCategoriasNotes)
        {
            var descCategoriasNotesParameter = descCategoriasNotes != null ?
                new ObjectParameter("descCategoriasNotes", descCategoriasNotes) :
                new ObjectParameter("descCategoriasNotes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insert_CategoriasNotes", descCategoriasNotesParameter);
        }
    
        public virtual int sp_Insert_Consultas(string nombreConsulta, string emailConsulta, string contenidoConsulta, string cuitConsulta, string domicilioConsulta, string residenciaConsulta, string cpConsulta, string telefonoConsulta)
        {
            var nombreConsultaParameter = nombreConsulta != null ?
                new ObjectParameter("NombreConsulta", nombreConsulta) :
                new ObjectParameter("NombreConsulta", typeof(string));
    
            var emailConsultaParameter = emailConsulta != null ?
                new ObjectParameter("EmailConsulta", emailConsulta) :
                new ObjectParameter("EmailConsulta", typeof(string));
    
            var contenidoConsultaParameter = contenidoConsulta != null ?
                new ObjectParameter("contenidoConsulta", contenidoConsulta) :
                new ObjectParameter("contenidoConsulta", typeof(string));
    
            var cuitConsultaParameter = cuitConsulta != null ?
                new ObjectParameter("cuitConsulta", cuitConsulta) :
                new ObjectParameter("cuitConsulta", typeof(string));
    
            var domicilioConsultaParameter = domicilioConsulta != null ?
                new ObjectParameter("domicilioConsulta", domicilioConsulta) :
                new ObjectParameter("domicilioConsulta", typeof(string));
    
            var residenciaConsultaParameter = residenciaConsulta != null ?
                new ObjectParameter("residenciaConsulta", residenciaConsulta) :
                new ObjectParameter("residenciaConsulta", typeof(string));
    
            var cpConsultaParameter = cpConsulta != null ?
                new ObjectParameter("cpConsulta", cpConsulta) :
                new ObjectParameter("cpConsulta", typeof(string));
    
            var telefonoConsultaParameter = telefonoConsulta != null ?
                new ObjectParameter("telefonoConsulta", telefonoConsulta) :
                new ObjectParameter("telefonoConsulta", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insert_Consultas", nombreConsultaParameter, emailConsultaParameter, contenidoConsultaParameter, cuitConsultaParameter, domicilioConsultaParameter, residenciaConsultaParameter, cpConsultaParameter, telefonoConsultaParameter);
        }
    
        public virtual int sp_Insert_ImagesSliderNotes(Nullable<int> idSliderNotes, string nameImagesSliderNotes, string descImagesSliderNotes, Nullable<bool> activeImagesSliderNotes, string urlImagesSliderNotes)
        {
            var idSliderNotesParameter = idSliderNotes.HasValue ?
                new ObjectParameter("IdSliderNotes", idSliderNotes) :
                new ObjectParameter("IdSliderNotes", typeof(int));
    
            var nameImagesSliderNotesParameter = nameImagesSliderNotes != null ?
                new ObjectParameter("nameImagesSliderNotes", nameImagesSliderNotes) :
                new ObjectParameter("nameImagesSliderNotes", typeof(string));
    
            var descImagesSliderNotesParameter = descImagesSliderNotes != null ?
                new ObjectParameter("descImagesSliderNotes", descImagesSliderNotes) :
                new ObjectParameter("descImagesSliderNotes", typeof(string));
    
            var activeImagesSliderNotesParameter = activeImagesSliderNotes.HasValue ?
                new ObjectParameter("activeImagesSliderNotes", activeImagesSliderNotes) :
                new ObjectParameter("activeImagesSliderNotes", typeof(bool));
    
            var urlImagesSliderNotesParameter = urlImagesSliderNotes != null ?
                new ObjectParameter("urlImagesSliderNotes", urlImagesSliderNotes) :
                new ObjectParameter("urlImagesSliderNotes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insert_ImagesSliderNotes", idSliderNotesParameter, nameImagesSliderNotesParameter, descImagesSliderNotesParameter, activeImagesSliderNotesParameter, urlImagesSliderNotesParameter);
        }
    
        public virtual int sp_Insert_Notes(string titleNote, string bodyNote, string imgNote, string tagsNote, string authorNote, Nullable<bool> activeNote, Nullable<int> idCategoriasNote, string imgSliderNote)
        {
            var titleNoteParameter = titleNote != null ?
                new ObjectParameter("titleNote", titleNote) :
                new ObjectParameter("titleNote", typeof(string));
    
            var bodyNoteParameter = bodyNote != null ?
                new ObjectParameter("bodyNote", bodyNote) :
                new ObjectParameter("bodyNote", typeof(string));
    
            var imgNoteParameter = imgNote != null ?
                new ObjectParameter("imgNote", imgNote) :
                new ObjectParameter("imgNote", typeof(string));
    
            var tagsNoteParameter = tagsNote != null ?
                new ObjectParameter("tagsNote", tagsNote) :
                new ObjectParameter("tagsNote", typeof(string));
    
            var authorNoteParameter = authorNote != null ?
                new ObjectParameter("authorNote", authorNote) :
                new ObjectParameter("authorNote", typeof(string));
    
            var activeNoteParameter = activeNote.HasValue ?
                new ObjectParameter("ActiveNote", activeNote) :
                new ObjectParameter("ActiveNote", typeof(bool));
    
            var idCategoriasNoteParameter = idCategoriasNote.HasValue ?
                new ObjectParameter("idCategoriasNote", idCategoriasNote) :
                new ObjectParameter("idCategoriasNote", typeof(int));
    
            var imgSliderNoteParameter = imgSliderNote != null ?
                new ObjectParameter("imgSliderNote", imgSliderNote) :
                new ObjectParameter("imgSliderNote", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insert_Notes", titleNoteParameter, bodyNoteParameter, imgNoteParameter, tagsNoteParameter, authorNoteParameter, activeNoteParameter, idCategoriasNoteParameter, imgSliderNoteParameter);
        }
    
        public virtual int sp_Insert_RespuestaConsultas(Nullable<int> idConsulta, string nombreRespuestaConsultas, string contenidoConsulta)
        {
            var idConsultaParameter = idConsulta.HasValue ?
                new ObjectParameter("IdConsulta", idConsulta) :
                new ObjectParameter("IdConsulta", typeof(int));
    
            var nombreRespuestaConsultasParameter = nombreRespuestaConsultas != null ?
                new ObjectParameter("NombreRespuestaConsultas", nombreRespuestaConsultas) :
                new ObjectParameter("NombreRespuestaConsultas", typeof(string));
    
            var contenidoConsultaParameter = contenidoConsulta != null ?
                new ObjectParameter("contenidoConsulta", contenidoConsulta) :
                new ObjectParameter("contenidoConsulta", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insert_RespuestaConsultas", idConsultaParameter, nombreRespuestaConsultasParameter, contenidoConsultaParameter);
        }
    
        public virtual int sp_Insert_SettingsIntegrationNotes(string descSettingsIntegrationNotes, string keySettingsIntegrationNotes, string valueSettingsIntegrationNotes, Nullable<bool> activeSettingsIntegrationNotes)
        {
            var descSettingsIntegrationNotesParameter = descSettingsIntegrationNotes != null ?
                new ObjectParameter("descSettingsIntegrationNotes", descSettingsIntegrationNotes) :
                new ObjectParameter("descSettingsIntegrationNotes", typeof(string));
    
            var keySettingsIntegrationNotesParameter = keySettingsIntegrationNotes != null ?
                new ObjectParameter("keySettingsIntegrationNotes", keySettingsIntegrationNotes) :
                new ObjectParameter("keySettingsIntegrationNotes", typeof(string));
    
            var valueSettingsIntegrationNotesParameter = valueSettingsIntegrationNotes != null ?
                new ObjectParameter("valueSettingsIntegrationNotes", valueSettingsIntegrationNotes) :
                new ObjectParameter("valueSettingsIntegrationNotes", typeof(string));
    
            var activeSettingsIntegrationNotesParameter = activeSettingsIntegrationNotes.HasValue ?
                new ObjectParameter("ActiveSettingsIntegrationNotes", activeSettingsIntegrationNotes) :
                new ObjectParameter("ActiveSettingsIntegrationNotes", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insert_SettingsIntegrationNotes", descSettingsIntegrationNotesParameter, keySettingsIntegrationNotesParameter, valueSettingsIntegrationNotesParameter, activeSettingsIntegrationNotesParameter);
        }
    
        public virtual int sp_Insert_SliderHome(string descSliderHome, string urlSliderHome, string urlImgSliderHome, string nameSliderHome, Nullable<bool> activeSliderHome)
        {
            var descSliderHomeParameter = descSliderHome != null ?
                new ObjectParameter("descSliderHome", descSliderHome) :
                new ObjectParameter("descSliderHome", typeof(string));
    
            var urlSliderHomeParameter = urlSliderHome != null ?
                new ObjectParameter("urlSliderHome", urlSliderHome) :
                new ObjectParameter("urlSliderHome", typeof(string));
    
            var urlImgSliderHomeParameter = urlImgSliderHome != null ?
                new ObjectParameter("urlImgSliderHome", urlImgSliderHome) :
                new ObjectParameter("urlImgSliderHome", typeof(string));
    
            var nameSliderHomeParameter = nameSliderHome != null ?
                new ObjectParameter("nameSliderHome", nameSliderHome) :
                new ObjectParameter("nameSliderHome", typeof(string));
    
            var activeSliderHomeParameter = activeSliderHome.HasValue ?
                new ObjectParameter("activeSliderHome", activeSliderHome) :
                new ObjectParameter("activeSliderHome", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insert_SliderHome", descSliderHomeParameter, urlSliderHomeParameter, urlImgSliderHomeParameter, nameSliderHomeParameter, activeSliderHomeParameter);
        }
    
        public virtual int sp_Insert_SliderNotes(string descSliderNotes)
        {
            var descSliderNotesParameter = descSliderNotes != null ?
                new ObjectParameter("descSliderNotes", descSliderNotes) :
                new ObjectParameter("descSliderNotes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insert_SliderNotes", descSliderNotesParameter);
        }
    
        public virtual ObjectResult<sp_Select_CategoriasNotes_Result> sp_Select_CategoriasNotes(Nullable<int> option, Nullable<int> idCategoriasNotes, string descCategoriasNotes)
        {
            var optionParameter = option.HasValue ?
                new ObjectParameter("option", option) :
                new ObjectParameter("option", typeof(int));
    
            var idCategoriasNotesParameter = idCategoriasNotes.HasValue ?
                new ObjectParameter("IdCategoriasNotes", idCategoriasNotes) :
                new ObjectParameter("IdCategoriasNotes", typeof(int));
    
            var descCategoriasNotesParameter = descCategoriasNotes != null ?
                new ObjectParameter("descCategoriasNotes", descCategoriasNotes) :
                new ObjectParameter("descCategoriasNotes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Select_CategoriasNotes_Result>("sp_Select_CategoriasNotes", optionParameter, idCategoriasNotesParameter, descCategoriasNotesParameter);
        }
    
        public virtual ObjectResult<sp_Select_Consultas_Result> sp_Select_Consultas(Nullable<int> option, Nullable<int> idConsulta, string nombreConsulta)
        {
            var optionParameter = option.HasValue ?
                new ObjectParameter("option", option) :
                new ObjectParameter("option", typeof(int));
    
            var idConsultaParameter = idConsulta.HasValue ?
                new ObjectParameter("IdConsulta", idConsulta) :
                new ObjectParameter("IdConsulta", typeof(int));
    
            var nombreConsultaParameter = nombreConsulta != null ?
                new ObjectParameter("NombreConsulta", nombreConsulta) :
                new ObjectParameter("NombreConsulta", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Select_Consultas_Result>("sp_Select_Consultas", optionParameter, idConsultaParameter, nombreConsultaParameter);
        }
    
        public virtual ObjectResult<sp_Select_ImagesSliderNotes_Result> sp_Select_ImagesSliderNotes(Nullable<int> option, Nullable<int> idImagesSliderNotes, Nullable<int> idSliderNotes, string nameImagesSliderNotes)
        {
            var optionParameter = option.HasValue ?
                new ObjectParameter("option", option) :
                new ObjectParameter("option", typeof(int));
    
            var idImagesSliderNotesParameter = idImagesSliderNotes.HasValue ?
                new ObjectParameter("IdImagesSliderNotes", idImagesSliderNotes) :
                new ObjectParameter("IdImagesSliderNotes", typeof(int));
    
            var idSliderNotesParameter = idSliderNotes.HasValue ?
                new ObjectParameter("IdSliderNotes", idSliderNotes) :
                new ObjectParameter("IdSliderNotes", typeof(int));
    
            var nameImagesSliderNotesParameter = nameImagesSliderNotes != null ?
                new ObjectParameter("nameImagesSliderNotes", nameImagesSliderNotes) :
                new ObjectParameter("nameImagesSliderNotes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Select_ImagesSliderNotes_Result>("sp_Select_ImagesSliderNotes", optionParameter, idImagesSliderNotesParameter, idSliderNotesParameter, nameImagesSliderNotesParameter);
        }
    
        public virtual ObjectResult<sp_Select_Notes_Result> sp_Select_Notes(Nullable<int> option, Nullable<int> idNote, string titleNote)
        {
            var optionParameter = option.HasValue ?
                new ObjectParameter("option", option) :
                new ObjectParameter("option", typeof(int));
    
            var idNoteParameter = idNote.HasValue ?
                new ObjectParameter("IdNote", idNote) :
                new ObjectParameter("IdNote", typeof(int));
    
            var titleNoteParameter = titleNote != null ?
                new ObjectParameter("titleNote", titleNote) :
                new ObjectParameter("titleNote", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Select_Notes_Result>("sp_Select_Notes", optionParameter, idNoteParameter, titleNoteParameter);
        }
    
        public virtual ObjectResult<sp_Select_SettingsIntegrationNotes_Result> sp_Select_SettingsIntegrationNotes(Nullable<int> option, Nullable<int> idSettingsIntegrationNotes, string descSettingsIntegrationNotes)
        {
            var optionParameter = option.HasValue ?
                new ObjectParameter("option", option) :
                new ObjectParameter("option", typeof(int));
    
            var idSettingsIntegrationNotesParameter = idSettingsIntegrationNotes.HasValue ?
                new ObjectParameter("IdSettingsIntegrationNotes", idSettingsIntegrationNotes) :
                new ObjectParameter("IdSettingsIntegrationNotes", typeof(int));
    
            var descSettingsIntegrationNotesParameter = descSettingsIntegrationNotes != null ?
                new ObjectParameter("descSettingsIntegrationNotes", descSettingsIntegrationNotes) :
                new ObjectParameter("descSettingsIntegrationNotes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Select_SettingsIntegrationNotes_Result>("sp_Select_SettingsIntegrationNotes", optionParameter, idSettingsIntegrationNotesParameter, descSettingsIntegrationNotesParameter);
        }
    
        public virtual ObjectResult<sp_Select_SliderHome_Result> sp_Select_SliderHome(Nullable<int> option, Nullable<int> idSlideHome, string descSlideHome)
        {
            var optionParameter = option.HasValue ?
                new ObjectParameter("option", option) :
                new ObjectParameter("option", typeof(int));
    
            var idSlideHomeParameter = idSlideHome.HasValue ?
                new ObjectParameter("IdSlideHome", idSlideHome) :
                new ObjectParameter("IdSlideHome", typeof(int));
    
            var descSlideHomeParameter = descSlideHome != null ?
                new ObjectParameter("descSlideHome", descSlideHome) :
                new ObjectParameter("descSlideHome", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Select_SliderHome_Result>("sp_Select_SliderHome", optionParameter, idSlideHomeParameter, descSlideHomeParameter);
        }
    
        public virtual ObjectResult<sp_Select_SliderNotes_Result> sp_Select_SliderNotes(Nullable<int> option, Nullable<int> idSliderNotes, string descSliderNotes)
        {
            var optionParameter = option.HasValue ?
                new ObjectParameter("option", option) :
                new ObjectParameter("option", typeof(int));
    
            var idSliderNotesParameter = idSliderNotes.HasValue ?
                new ObjectParameter("IdSliderNotes", idSliderNotes) :
                new ObjectParameter("IdSliderNotes", typeof(int));
    
            var descSliderNotesParameter = descSliderNotes != null ?
                new ObjectParameter("descSliderNotes", descSliderNotes) :
                new ObjectParameter("descSliderNotes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Select_SliderNotes_Result>("sp_Select_SliderNotes", optionParameter, idSliderNotesParameter, descSliderNotesParameter);
        }
    
        public virtual int sp_Update_Consultas_id(Nullable<int> idConsulta, string nombreConsulta, string emailConsulta, string contenidoConsulta, string cuitConsulta, string domicilioConsulta, string residenciaConsulta, string cpConsulta, string telefonoConsulta)
        {
            var idConsultaParameter = idConsulta.HasValue ?
                new ObjectParameter("IdConsulta", idConsulta) :
                new ObjectParameter("IdConsulta", typeof(int));
    
            var nombreConsultaParameter = nombreConsulta != null ?
                new ObjectParameter("NombreConsulta", nombreConsulta) :
                new ObjectParameter("NombreConsulta", typeof(string));
    
            var emailConsultaParameter = emailConsulta != null ?
                new ObjectParameter("EmailConsulta", emailConsulta) :
                new ObjectParameter("EmailConsulta", typeof(string));
    
            var contenidoConsultaParameter = contenidoConsulta != null ?
                new ObjectParameter("contenidoConsulta", contenidoConsulta) :
                new ObjectParameter("contenidoConsulta", typeof(string));
    
            var cuitConsultaParameter = cuitConsulta != null ?
                new ObjectParameter("cuitConsulta", cuitConsulta) :
                new ObjectParameter("cuitConsulta", typeof(string));
    
            var domicilioConsultaParameter = domicilioConsulta != null ?
                new ObjectParameter("domicilioConsulta", domicilioConsulta) :
                new ObjectParameter("domicilioConsulta", typeof(string));
    
            var residenciaConsultaParameter = residenciaConsulta != null ?
                new ObjectParameter("residenciaConsulta", residenciaConsulta) :
                new ObjectParameter("residenciaConsulta", typeof(string));
    
            var cpConsultaParameter = cpConsulta != null ?
                new ObjectParameter("cpConsulta", cpConsulta) :
                new ObjectParameter("cpConsulta", typeof(string));
    
            var telefonoConsultaParameter = telefonoConsulta != null ?
                new ObjectParameter("telefonoConsulta", telefonoConsulta) :
                new ObjectParameter("telefonoConsulta", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Update_Consultas_id", idConsultaParameter, nombreConsultaParameter, emailConsultaParameter, contenidoConsultaParameter, cuitConsultaParameter, domicilioConsultaParameter, residenciaConsultaParameter, cpConsultaParameter, telefonoConsultaParameter);
        }
    
        public virtual int sp_Update_ImagesSliderNotes_id(Nullable<int> idSliderNotes, Nullable<int> idImagesSliderNotes, string nameImagesSliderNotes, string descImagesSliderNotes, Nullable<bool> activeImagesSliderNotes, string urlImagesSliderNotes)
        {
            var idSliderNotesParameter = idSliderNotes.HasValue ?
                new ObjectParameter("IdSliderNotes", idSliderNotes) :
                new ObjectParameter("IdSliderNotes", typeof(int));
    
            var idImagesSliderNotesParameter = idImagesSliderNotes.HasValue ?
                new ObjectParameter("IdImagesSliderNotes", idImagesSliderNotes) :
                new ObjectParameter("IdImagesSliderNotes", typeof(int));
    
            var nameImagesSliderNotesParameter = nameImagesSliderNotes != null ?
                new ObjectParameter("nameImagesSliderNotes", nameImagesSliderNotes) :
                new ObjectParameter("nameImagesSliderNotes", typeof(string));
    
            var descImagesSliderNotesParameter = descImagesSliderNotes != null ?
                new ObjectParameter("descImagesSliderNotes", descImagesSliderNotes) :
                new ObjectParameter("descImagesSliderNotes", typeof(string));
    
            var activeImagesSliderNotesParameter = activeImagesSliderNotes.HasValue ?
                new ObjectParameter("activeImagesSliderNotes", activeImagesSliderNotes) :
                new ObjectParameter("activeImagesSliderNotes", typeof(bool));
    
            var urlImagesSliderNotesParameter = urlImagesSliderNotes != null ?
                new ObjectParameter("urlImagesSliderNotes", urlImagesSliderNotes) :
                new ObjectParameter("urlImagesSliderNotes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Update_ImagesSliderNotes_id", idSliderNotesParameter, idImagesSliderNotesParameter, nameImagesSliderNotesParameter, descImagesSliderNotesParameter, activeImagesSliderNotesParameter, urlImagesSliderNotesParameter);
        }
    
        public virtual int sp_Update_Notes_id(Nullable<int> idNote, string titleNote, string bodyNote, string imgNote, string tagsNote, string authorNote, Nullable<bool> activeNote, Nullable<int> idCategoriasNote, string imgSliderNote)
        {
            var idNoteParameter = idNote.HasValue ?
                new ObjectParameter("IdNote", idNote) :
                new ObjectParameter("IdNote", typeof(int));
    
            var titleNoteParameter = titleNote != null ?
                new ObjectParameter("titleNote", titleNote) :
                new ObjectParameter("titleNote", typeof(string));
    
            var bodyNoteParameter = bodyNote != null ?
                new ObjectParameter("bodyNote", bodyNote) :
                new ObjectParameter("bodyNote", typeof(string));
    
            var imgNoteParameter = imgNote != null ?
                new ObjectParameter("imgNote", imgNote) :
                new ObjectParameter("imgNote", typeof(string));
    
            var tagsNoteParameter = tagsNote != null ?
                new ObjectParameter("tagsNote", tagsNote) :
                new ObjectParameter("tagsNote", typeof(string));
    
            var authorNoteParameter = authorNote != null ?
                new ObjectParameter("authorNote", authorNote) :
                new ObjectParameter("authorNote", typeof(string));
    
            var activeNoteParameter = activeNote.HasValue ?
                new ObjectParameter("ActiveNote", activeNote) :
                new ObjectParameter("ActiveNote", typeof(bool));
    
            var idCategoriasNoteParameter = idCategoriasNote.HasValue ?
                new ObjectParameter("idCategoriasNote", idCategoriasNote) :
                new ObjectParameter("idCategoriasNote", typeof(int));
    
            var imgSliderNoteParameter = imgSliderNote != null ?
                new ObjectParameter("imgSliderNote", imgSliderNote) :
                new ObjectParameter("imgSliderNote", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Update_Notes_id", idNoteParameter, titleNoteParameter, bodyNoteParameter, imgNoteParameter, tagsNoteParameter, authorNoteParameter, activeNoteParameter, idCategoriasNoteParameter, imgSliderNoteParameter);
        }
    
        public virtual int sp_Update_RespuestaConsultas_id(Nullable<int> idRespuestaConsultas, Nullable<int> idConsulta, string nombreRespuestaConsultas, string contenidoConsulta)
        {
            var idRespuestaConsultasParameter = idRespuestaConsultas.HasValue ?
                new ObjectParameter("IdRespuestaConsultas", idRespuestaConsultas) :
                new ObjectParameter("IdRespuestaConsultas", typeof(int));
    
            var idConsultaParameter = idConsulta.HasValue ?
                new ObjectParameter("IdConsulta", idConsulta) :
                new ObjectParameter("IdConsulta", typeof(int));
    
            var nombreRespuestaConsultasParameter = nombreRespuestaConsultas != null ?
                new ObjectParameter("NombreRespuestaConsultas", nombreRespuestaConsultas) :
                new ObjectParameter("NombreRespuestaConsultas", typeof(string));
    
            var contenidoConsultaParameter = contenidoConsulta != null ?
                new ObjectParameter("contenidoConsulta", contenidoConsulta) :
                new ObjectParameter("contenidoConsulta", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Update_RespuestaConsultas_id", idRespuestaConsultasParameter, idConsultaParameter, nombreRespuestaConsultasParameter, contenidoConsultaParameter);
        }
    
        public virtual int sp_Update_SettingsIntegrationNotes_id(Nullable<int> idSettingsIntegrationNotes, string descSettingsIntegrationNotes, string keySettingsIntegrationNotes, string valueSettingsIntegrationNotes, Nullable<bool> activeSettingsIntegrationNotes)
        {
            var idSettingsIntegrationNotesParameter = idSettingsIntegrationNotes.HasValue ?
                new ObjectParameter("IdSettingsIntegrationNotes", idSettingsIntegrationNotes) :
                new ObjectParameter("IdSettingsIntegrationNotes", typeof(int));
    
            var descSettingsIntegrationNotesParameter = descSettingsIntegrationNotes != null ?
                new ObjectParameter("descSettingsIntegrationNotes", descSettingsIntegrationNotes) :
                new ObjectParameter("descSettingsIntegrationNotes", typeof(string));
    
            var keySettingsIntegrationNotesParameter = keySettingsIntegrationNotes != null ?
                new ObjectParameter("keySettingsIntegrationNotes", keySettingsIntegrationNotes) :
                new ObjectParameter("keySettingsIntegrationNotes", typeof(string));
    
            var valueSettingsIntegrationNotesParameter = valueSettingsIntegrationNotes != null ?
                new ObjectParameter("valueSettingsIntegrationNotes", valueSettingsIntegrationNotes) :
                new ObjectParameter("valueSettingsIntegrationNotes", typeof(string));
    
            var activeSettingsIntegrationNotesParameter = activeSettingsIntegrationNotes.HasValue ?
                new ObjectParameter("ActiveSettingsIntegrationNotes", activeSettingsIntegrationNotes) :
                new ObjectParameter("ActiveSettingsIntegrationNotes", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Update_SettingsIntegrationNotes_id", idSettingsIntegrationNotesParameter, descSettingsIntegrationNotesParameter, keySettingsIntegrationNotesParameter, valueSettingsIntegrationNotesParameter, activeSettingsIntegrationNotesParameter);
        }
    
        public virtual int sp_Update_SliderHome_id(Nullable<int> idSliderHome, string descSliderHome, string urlSliderHome, string urlImgSliderHome, string nameSliderHome, Nullable<bool> activeSliderHome)
        {
            var idSliderHomeParameter = idSliderHome.HasValue ?
                new ObjectParameter("IdSliderHome", idSliderHome) :
                new ObjectParameter("IdSliderHome", typeof(int));
    
            var descSliderHomeParameter = descSliderHome != null ?
                new ObjectParameter("descSliderHome", descSliderHome) :
                new ObjectParameter("descSliderHome", typeof(string));
    
            var urlSliderHomeParameter = urlSliderHome != null ?
                new ObjectParameter("urlSliderHome", urlSliderHome) :
                new ObjectParameter("urlSliderHome", typeof(string));
    
            var urlImgSliderHomeParameter = urlImgSliderHome != null ?
                new ObjectParameter("urlImgSliderHome", urlImgSliderHome) :
                new ObjectParameter("urlImgSliderHome", typeof(string));
    
            var nameSliderHomeParameter = nameSliderHome != null ?
                new ObjectParameter("nameSliderHome", nameSliderHome) :
                new ObjectParameter("nameSliderHome", typeof(string));
    
            var activeSliderHomeParameter = activeSliderHome.HasValue ?
                new ObjectParameter("activeSliderHome", activeSliderHome) :
                new ObjectParameter("activeSliderHome", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Update_SliderHome_id", idSliderHomeParameter, descSliderHomeParameter, urlSliderHomeParameter, urlImgSliderHomeParameter, nameSliderHomeParameter, activeSliderHomeParameter);
        }
    
        public virtual int sp_Update_SliderNotes_id(Nullable<int> idSliderNotes, string descSliderNotes)
        {
            var idSliderNotesParameter = idSliderNotes.HasValue ?
                new ObjectParameter("IdSliderNotes", idSliderNotes) :
                new ObjectParameter("IdSliderNotes", typeof(int));
    
            var descSliderNotesParameter = descSliderNotes != null ?
                new ObjectParameter("descSliderNotes", descSliderNotes) :
                new ObjectParameter("descSliderNotes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Update_SliderNotes_id", idSliderNotesParameter, descSliderNotesParameter);
        }
    }
}
