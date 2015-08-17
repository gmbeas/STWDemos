using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using WcfWebNueva.Content;

namespace WcfWebNueva
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceSTW : IServiceSTW
    {
        public List<DemoNivelModel> DemoNiveles(int tieid, string arbol, string nivel)
        {
            //'CPF', 29 ,'49806,49817' ,0,'','','1'
           
            var ds = DbGeneral.WPL_POW_Arbol("CPF", tieid, arbol, 0, "", "", nivel, "");
            var lst = ds.Tables[0].ToList<DemoNivelModel>();
            
            return lst;
        }

        


        public BannerModel GetBanners()
        {
            var banFinal = new BannerModel();

            var banGrande = new List<BannerGrandeModel>();
            var banChico = new List<BannerChicoModel>();

            for (int i = 1; i < 5; i++)
            {
                var dsGUrl = DbGeneral.WPL_LeeParametrosAdminWeb("LEE", "ADMIN_WEB_IMG_HOME_1", i.ToString(), "", "", 0);
                var drGUrl = dsGUrl.Tables[0].Rows[0];
                var dsGLink = DbGeneral.WPL_LeeParametrosAdminWeb("LEE", "ADMIN_WEB_LINK_HOME_1", i.ToString(), "", "", 0);
                var drGLink = dsGLink.Tables[0].Rows[0];

                var dsCUrl = DbGeneral.WPL_LeeParametrosAdminWeb("LEE", "ADMIN_WEB_IMG_HOME_2", i.ToString(), "", "", 0);
                var drCurl = dsCUrl.Tables[0].Rows[0];
                var dsCLink = DbGeneral.WPL_LeeParametrosAdminWeb("LEE", "ADMIN_WEB_LINK_HOME_2", i.ToString(), "", "", 0);
                var drCLink = dsCLink.Tables[0].Rows[0];

                banGrande.Add(new BannerGrandeModel
                {
                    Imagen = drGUrl["Valor"].ToString(),
                    Link = drGLink["Valor"].ToString()
                });

                banChico.Add(new BannerChicoModel
                {
                    Imagen = drCurl["Valor"].ToString(),
                    Link = drCLink["Valor"].ToString()
                });
            }

            banFinal.BannerChico = banChico;
            banFinal.BannerGrande = banGrande;

            return banFinal;
        }

        

        public FinalCategoriaModel TraeSubCategoria(int tieId, string arbol)
        {
            var nivel = 1;
            if (arbol.Contains(","))
            {
                nivel = 2;
            }
            var ds = DbGeneral.WPL_Sku_Atributos("SPT", 'X', 'N', "STE", "", 1, tieId, arbol, nivel, "", "", "", "", "", "0",
                "", "N", 1, "", "", 0, "");

            var nomb = "";
            var dato = new List<SubCateModel>();
            var subdato = new List<SubCategoriaModel>();
            var final = new FinalCategoriaModel();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["PRF_Id"].ToString() != "")
                {
                    if (dr["Nivel"].ToString() == "0")
                    {
                        if (dr["PRF_Id"].ToString() != nomb)
                        {
                           dato.Add(new SubCateModel
                           {
                               Prefijo = dr["Prefijo"].ToString(),
                               PrfId = dr["Prf_id"].ToString()
                           });

                            nomb = dr["PRF_Id"].ToString();
                        }
                    }
                    else if (dr["Nivel"].ToString() == "2")
                    {
                        subdato.Add(new SubCategoriaModel
                        {
                            Prefijo = dr["Prefijo"].ToString(),
                            PrfId = dr["Prf_id"].ToString()
                        });
                    }
                }
            }

            final.Categoria = dato;
            final.Subcategoria = subdato;

           
            return final;
        }

        


        public class ArbolCompletoClaseV2
        {
            public string Orden { get; set; }
            public string Nombre { get; set; }
            public string NavId { get; set; }
            public string Nivel { get; set; }
            public string Arbol { get; set; }
            public string PrfId { get; set; }
            public string TieId { get; set; }
            public string Tipo { get; set; }
        }

        public class ArbolNivelv2
        {
            public string Nombre { get; set; }
            public string NavId { get; set; }
            public string Arbol { get; set; }
            public string PrfId { get; set; }
            public string TieId { get; set; }
            public string Tipo { get; set; }

            public List<ArbolNivelv2> Nivel = new List<ArbolNivelv2>();

        }

        public class ArbolPrefijov2
        {
            public string Nombre { get; set; }
            public string NavId { get; set; }

            public List<ArbolNivelv2> Nivel = new List<ArbolNivelv2>();
            public string Arbol { get; set; }
            public string PrfId { get; set; }
            public string TieId { get; set; }
            public string Tipo { get; set; }
           

        }

        public class ArbolPrefijoNivelv2
        {
            public string Nombre { get; set; }
            public string NavId { get; set; }
            public string Arbol { get; set; }
            public string PrfId { get; set; }
            public string TieId { get; set; }
            public string Tipo { get; set; }

            public List<ArbolPrefijov2> Nivel = new List<ArbolPrefijov2>();

        }
        public List<ArbolPrefijoNivelv2> ArbolCompletoV2(string tipo, int tieid)
        {
            var ds = DbGeneral.ArbolCompleto(tipo, tieid, "", 0, "", "", "", "");
            var listado = (from DataRow dr in ds.Tables[0].Rows
                select new ArbolCompletoClaseV2
                {
                    Orden = dr["Orden"].ToString(), 
                    Nombre = dr["Nombre"].ToString(), 
                    NavId = dr["NIV_Id"].ToString(), 
                    Nivel = dr["Nivel"].ToString(), 
                    Arbol = dr["Arbol"].ToString(), 
                    PrfId = dr["PRF_Id"].ToString(), 
                    TieId = dr["TIE_Id"].ToString(), 
                    Tipo = dr["Tipo"].ToString()
                }).ToList();

            var nivelx1 = new List<ArbolNivelv2>();
            var nivelx2 = new List<ArbolNivelv2>();
            var nivelx3 = new List<ArbolNivelv2>();
            var nivelx4 = new List<ArbolNivelv2>();

            
            foreach (var t in listado)
            {
                if (t.Nivel == "1" && t.Tipo == "1")
                {
                    nivelx1.Add(new ArbolNivelv2
                    {
                        Arbol = t.Arbol,
                        Nombre = t.Nombre,
                        NavId = t.NavId,
                        PrfId = t.PrfId,
                        TieId = t.TieId,
                        Tipo = t.Tipo
                    });
                }
                else if (t.Nivel == "2" && t.Tipo == "1")
                {
                    nivelx2.Add(new ArbolNivelv2
                    {
                        Arbol = t.Arbol,
                        Nombre = t.Nombre,
                        NavId = t.NavId,
                        PrfId = t.PrfId,
                        TieId = t.TieId,
                        Tipo = t.Tipo
                    });
                }
                else if (t.Nivel == "3" && t.Tipo == "1")
                {
                    nivelx3.Add(new ArbolNivelv2
                    {
                        Arbol = t.Arbol,
                        Nombre = t.Nombre,
                        NavId = t.NavId,
                        PrfId = t.PrfId,
                        TieId = t.TieId,
                        Tipo = t.Tipo
                    });
                }
                else if (t.Nivel == "4")
                {
                    nivelx4.Add(new ArbolNivelv2
                    {
                        Arbol = t.Arbol,
                        Nombre = t.Nombre,
                        NavId = t.NavId,
                        PrfId = t.PrfId,
                        TieId = t.TieId,
                        Tipo = t.Tipo
                    });
                }
            }


            var info = new List<ArbolPrefijoNivelv2>();
            foreach (var t in nivelx1.OrderBy(x => x.Nombre))
            {
                var nivel = new List<ArbolPrefijov2>();
                foreach (var n in nivelx2.OrderBy(x => x.Nombre))
                {
                    
                    var aa = n.Arbol.Split(',');
                    
                    if (aa[0] == t.NavId)
                    {
                        var pp = new List<ArbolNivelv2>();
                        foreach (var z in nivelx3)
                        {
                            var uu = z.Arbol.Split(',');
                            if (n.NavId == uu[1])
                            {
                                var au =new List<ArbolNivelv2>();
                                foreach (var u in nivelx4)
                                {
                                    var uuu = u.Arbol.Split(',');
                                    if (uuu[2] == uu[2])
                                    {
                                        var ppxx= uuu[2];
                                        au.Add(new ArbolNivelv2
                                        {
                                            Nombre = u.Nombre,
                                            Arbol = u.Arbol,
                                            NavId = u.NavId,
                                            PrfId = u.PrfId,
                                            TieId = u.TieId,
                                            Tipo = u.Tipo
                                        });
                                    }
                                }

                                pp.Add(new ArbolNivelv2
                                {
                                    Nombre = z.Nombre,
                                    Arbol = z.Arbol,
                                    NavId = z.NavId,
                                    PrfId = z.PrfId,
                                    TieId = z.TieId,
                                    Tipo = z.Tipo,
                                    Nivel = au
                                });
                            }
                        }

                        var tta = new List<ArbolNivelv2>();
                        foreach (var x in listado)
                        {
                            if (x.Tipo == "0" && x.Nivel == "3")
                            {
                                var bb = x.Arbol.Split(',');
                                if (bb[1] == n.NavId)
                                {
                                    pp.Add(new ArbolNivelv2
                                    {
                                        Nombre = x.Nombre,
                                        Arbol = x.Arbol,
                                        NavId = x.NavId,
                                        PrfId = x.PrfId,
                                        TieId = x.TieId,
                                        Tipo = x.Tipo
                                    });
                                }
                            }
                           
                        }

                        nivel.Add(new ArbolPrefijov2
                        {
                            Nombre = n.Nombre,
                            Nivel = new List<ArbolNivelv2>(pp.OrderBy(x=>x.Nombre)),
                            Arbol = n.Arbol,
                            NavId = n.NavId,
                            PrfId = n.PrfId,
                            TieId = n.TieId,
                            Tipo = n.Tipo
                        });
                    }
                }

                info.Add(new ArbolPrefijoNivelv2
                {
                    Nombre = t.Nombre,
                    Nivel = new List<ArbolPrefijov2>(nivel.OrderBy(x => x.Nombre)),
                    Arbol = t.Arbol,
                    NavId = t.NavId,
                    PrfId = t.PrfId,
                    TieId = t.TieId,
                    Tipo = t.Tipo
                });
            }
           


            var final = new List<ArbolNivelCompleto>();
            return info.ToList();

        }
        public List<ArbolNivelCompleto> ArbolCompleto(string tipo, int tieid)
        {
            var ds = DbGeneral.ArbolCompleto(tipo, tieid, "", 0, "", "", "", "");
            var listado = (from DataRow dr in ds.Tables[0].Rows
                select new ArbolCompleto
                {
                    Orden = dr["orden"].ToString(), 
                    Nombre = dr["nombre"].ToString(), 
                    NavId = dr["niv_id"].ToString(), 
                    Nivel = dr["nivel"].ToString(), 
                    Arbol = dr["Arbol"].ToString(), 
                    ArbolRama = dr["ArbolRama"].ToString(), 
                    ArbId = dr["ARB_Id"].ToString(), 
                    PrfId = dr["PRF_Id"].ToString(), 
                    Prefijo = dr["Prefijo"].ToString(), 
                    FotoArbol = dr["FotoArbol"].ToString(), 
                    TieId = dr["TIE_Id"].ToString(), 
                    Tipo = dr["Tipo"].ToString()
                }).ToList();


            
            var nivelx2 = new List<ArbolNivel>();
            var nivelx1 = new List<ArbolNivel>();
            var nivelx3 = new List<ArbolNivel>();
            foreach (var t in listado)
            {
                if (t.Nivel == "2")
                {
                    nivelx2.Add(new ArbolNivel
                    {
                        Arbol =  t.Arbol,
                        ArbolId = t.ArbId,
                        Nombre = t.Nombre
                    });
                }
                if (t.Nivel == "1")
                {
                    nivelx1.Add(new ArbolNivel
                    {
                        Arbol = t.Arbol,
                        ArbolId = t.ArbId,
                        Nombre = t.Nombre
                    });
                }
                if (t.Nivel == "3")
                {
                    nivelx3.Add(new ArbolNivel
                    {
                        Arbol = t.Arbol,
                        ArbolId = t.ArbId,
                        Nombre = t.Nombre
                    });
                }
            }

            var final = new List<ArbolNivelCompleto>();
            foreach (var t in nivelx1)
            {
                var lista2 = new List<ArbolNivel3>();
                

                

                foreach (var x in nivelx2)
                {
                    var arbol = x.Arbol.Split(',');
                    if (t.Arbol == arbol[0])
                    {
                        var lista3 = new List<ArbolNivel>();
                        foreach (var r in nivelx3)
                        {
                            var arbol3 = r.Arbol.Split(',');
                            if (arbol3.Any())
                            {
                                if (arbol[1] == arbol3[1])
                                {
                                    lista3.Add(new ArbolNivel
                                    {
                                        Arbol = r.Arbol,
                                        ArbolId = r.ArbolId,
                                        Nombre = r.Nombre
                                    });
                                }
                            }
                        }


                        lista2.Add(new ArbolNivel3
                        {
                            Arbol = x.Arbol,
                            ArbolId = x.ArbolId,
                            Nombre = x.Nombre,
                            Nivel = lista3
                        });
                    }
                }




                final.Add(new ArbolNivelCompleto
                {
                    Nombre = t.Nombre,
                    Arbol = t.Arbol,
                    ArbolId = t.ArbolId,
                    Nivel = lista2
                });
            }


            return final.ToList();
        }

       


        public List<ArbolAtributosNew> WPL_Sku_AtributosNew(string tipo, char stock, char disponible, string empresa, string prefijo,
            float nroskus, int tieId, string arbol,
            int arbolNivel, string mbArtNom, string mbFamCod, string mbClaCod, string mbMerCod, string mbGrpCod,
            string prfId, string bodega, string busquedaExacta,
            int skuActivo, string fechaDesde, string fechaHasta, int idAtrCliente, string codPromo)

        {
            var ds = DbGeneral.WPL_Sku_Atributos(tipo, stock, disponible, empresa, prefijo, nroskus, tieId, arbol, arbolNivel, mbArtNom, mbFamCod, mbClaCod, mbMerCod, mbGrpCod, prfId, bodega, busquedaExacta, skuActivo, fechaDesde, fechaHasta, idAtrCliente, codPromo);
            var listado = (from DataRow dr in ds.Tables[0].Rows
                           select new ArbolAtributosNew
                           {
                               Ok = int.Parse(dr["Ok"].ToString()),
                               PrefId = dr["PRF_Id"].ToString(),
                               Nivel = int.Parse(dr["Nivel"].ToString()),
                               Prefijo = dr["Prefijo"].ToString(),
                               Grupo = dr["Grupo"].ToString(),
                               AtdId = int.Parse(dr["ATD_Id"].ToString()),
                               GrpId = int.Parse(dr["GRP_Id"].ToString()),
                               Atributo = dr["Atributo"].ToString(),
                               Stock = int.Parse(dr["Stock"].ToString()),
                               Disponible = int.Parse(dr["Disponible"].ToString()),
                               EsLinea = dr["EsLinea"].ToString(),
                               Orden = int.Parse(dr["Orden"].ToString()),
                               FotoPrefijo = dr["FotoPrefijo"].ToString(),
                               FotoArbol = dr["FotoArbol"].ToString(),
                               Tipo = int.Parse(dr["Tipo"].ToString())
                           }).ToList();

            return listado.ToList();
        }

       

        public BusquedaModel WPL_Sku_Atributos_Busqueda(string busqueda, int tieId)
        {
            var ds = DbGeneral.WPL_Sku_Atributos("SPB", 'X', 'N', "STE", busqueda, 1, tieId, "", 1, "", "0", "0", "0", "0", "0", "0", "N", 1, "", "", 0, "");

            var info = new BusquedaModel();
            var infoProd = new List<BusquedaProductosModel>();

            var pp = new List<LineaUno>(); //LINEA DE PRODUCTOS
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["eslinea"].ToString() == "S")
                {
                    pp.Add(new LineaUno
                    {
                        Atributo = dr["Atributo"].ToString(),
                        AtdId = dr["ATD_ID"].ToString()
                    });
                }
            }

            var prefijo = "";
            var grupo = "";
            var atributo = "";
            var ppa = new List<ListPrefijo>();
            var ppa2 = new List<ListGrupo>();
            var ppa3 = new List<ListAtributo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["Nivel"].ToString() == "0")
                {
                    if (dr["tiporegistro"].ToString() == "1")
                    {
                        if (dr["prefijo"].ToString() != prefijo)
                        {
                            prefijo = dr["prefijo"].ToString();
                            ppa.Add(new ListPrefijo
                            {
                                Prefijo = dr["Prefijo"].ToString(),
                                PrefId = dr["Prf_Id"].ToString(),
                                Nivel = dr["Nivel"].ToString()
                            });
                        }
                    }
                }
            }

            var aux1 = new List<ListPrefijo>();
            foreach (var t in ppa)
            {
                var aux2 = new List<ListGrupo>();
                var grupox = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (t.Prefijo == dr["prefijo"].ToString())
                    {
                        if (grupox != dr["grupo"].ToString())
                        {
                            grupox = dr["grupo"].ToString();
                            aux2.Add(new ListGrupo
                            {
                                Grupo = dr["Grupo"].ToString()
                            });
                        }
                        
                    }
                }

                var aux4 = new List<ListGrupo>();
                foreach (var x in aux2)
                {
                    var atributox = "";
                    var aux3 = new List<ListAtributo>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (x.Grupo == dr["grupo"].ToString())
                        {
                            if (atributox != dr["Atributo"].ToString())
                            {
                                atributox = dr["Atributo"].ToString();
                                aux3.Add(new ListAtributo
                                {
                                    Atributo = dr["Atributo"].ToString(),
                                    AtdId = dr["Atd_Id"].ToString()
                                });
                            }
                        }
                    }

                    aux4.Add(new ListGrupo
                    {
                        Grupo = x.Grupo,
                        Atributo = aux3
                    });
                }

                aux1.Add(new ListPrefijo
                {
                    Prefijo = t.Prefijo,
                    PrefId = t.PrefId,
                    Nivel = t.Nivel,
                    Grupo = aux4
                });
            }
            



            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["TipoRegistro"].ToString() == "9")
                {
                    infoProd.Add(new BusquedaProductosModel
                    {
                        SkuId = dr["SKU_id"].ToString(),
                        Sku = dr["SKU"].ToString(),
                        NombreSku = dr["NombreSku"].ToString(),
                        NombreWeb = dr["NombreWeb"].ToString(),
                        Stock = dr["Stock"].ToString(),
                        Disponible = dr["Disponible"].ToString(),
                        Lista = dr["Lista"].ToString(),
                        PrecioUnidad = dr["PrecioUnidad"].ToString(),
                        PrecioUnidadNeto = dr["PrecioUnidadNeto"].ToString(),
                        Um = dr["Um"].ToString(),
                        FactorUm = dr["FactorUM"].ToString(),
                        Precio = dr["Precio"].ToString(),
                        PrecioNeto = dr["PrecioNeto"].ToString(),
                        Foto = dr["Foto"].ToString(),
                        IndStock = dr["IndStock"].ToString(),
                        PrfId = dr["PRF_Id"].ToString()
                    });
                }
            }

            info.Productos = infoProd;
            info.Prefijos = aux1;
            info.LineaProductos = pp;


            return info;
        }

        public UsuarioWeb GetUsuarioWeb(string tipo, string rut, string dv, string clave, int prfId, string rutDep,
            string rutAdmin, string nombre, string apeP, string apeM, string fantasia,
            string eMail, string telefono, string celular, string fax, string sitioWeb, string esEmpresa,
            string esFactura, int activo, int usrId)
        {
            var ds = DbGeneral.WPL_POW_Usuarios(tipo, rut, dv, clave, prfId, rutDep, rutAdmin, nombre, apeP, apeM, fantasia, eMail, telefono, celular, fax, sitioWeb, esEmpresa, esFactura, activo, usrId);

            var dr = ds.Tables[0].Rows[0];

            var respuesta = new UsuarioWeb();
            respuesta.Flag = dr["Flag"].ToString();
            respuesta.Id = dr["Id"].ToString();
            respuesta.Rut = dr["Rut"].ToString();
            respuesta.Dv = dr["Dv"].ToString();
            respuesta.RazonSocial = dr["RazonSocial"].ToString();
            respuesta.Fantasia = dr["Fantasia"].ToString();
            respuesta.Nombre = dr["Nombre"].ToString();
            respuesta.ApeP = dr["ApeP"].ToString();
            respuesta.ApeM = dr["ApeM"].ToString();
            respuesta.Email = dr["EMail"].ToString();
            respuesta.Telefono = dr["Telefono"].ToString();
            respuesta.Celular = dr["Celular"].ToString();
            respuesta.Fax = dr["Fax"].ToString();
            respuesta.SitioWeb = dr["SitioWeb"].ToString();
            respuesta.EsEmpresa = dr["EsEmpresa"].ToString();
            respuesta.EsFactura = dr["EsFactura"].ToString();
            return respuesta;
        }

        public Autentificacion Autentifica(string tipo, string rut, string dv, string clave, int prfId, string rutDep, string rutAdmin, string nombre, string apeP, string apeM, string fantasia,
           string eMail, string telefono, string celular, string fax, string sitioWeb, string esEmpresa, string esFactura, int activo, int usrId)

        {
            var ds = DbGeneral.WPL_POW_Usuarios(tipo, rut, dv, Helper.Encripta(clave), prfId, rutDep, rutAdmin, nombre, apeP, apeM, fantasia,
           eMail, telefono, celular, fax, sitioWeb, esEmpresa, esFactura, activo, usrId);

            var dr = ds.Tables[0].Rows[0];

            var respuesta = new Autentificacion();
            respuesta.Flag = dr["Flag"].ToString();
            respuesta.UsrId = dr["USR_Id"].ToString();
            respuesta.Mensaje = dr["Mensaje"].ToString();

            return respuesta;
        }

        public List<Arbol0Web> WPL_POW_Arbol(string tipo, int tieId, string arbol, int nivel, string codCliente, string sku, string subTipo, string codPromo)
        {
            var ds = DbGeneral.WPL_POW_Arbol(tipo, tieId, arbol, nivel, codCliente, sku, subTipo, codPromo);
            var listado = (from DataRow dr in ds.Tables[0].Rows
                           select new Arbol0Web
                           {
                               Arbol = int.Parse(dr["Arbol"].ToString()),
                               Nivel = int.Parse(dr["Nivel"].ToString()),
                               Nombre = dr["Nombre"].ToString(),
                               FotoArbol = dr["FotoArbol"].ToString(),
                               TieId = int.Parse(dr["TIE_Id"].ToString()),
                               NivId = int.Parse(dr["NIV_Id"].ToString())
                           }).ToList();

            return listado.ToList();
        }

        public List<ArbolAtributos> WPL_Sku_Atributos(string tipo, char stock, char disponible, string empresa, string prefijo, float nroskus, int tieId, string arbol, 
            int arbolNivel, string mbArtNom, string mbFamCod, string mbClaCod, string mbMerCod, string mbGrpCod, string prfId, string bodega, string busquedaExacta, 
            int skuActivo, string fechaDesde, string fechaHasta, int idAtrCliente, string codPromo)
        {
            var ds = DbGeneral.WPL_Sku_Atributos(tipo, stock, disponible, empresa, prefijo, nroskus, tieId, arbol, arbolNivel, mbArtNom, mbFamCod, mbClaCod, mbMerCod, mbGrpCod, prfId, bodega, busquedaExacta, skuActivo, fechaDesde, fechaHasta, idAtrCliente, codPromo);
            var listado = (from DataRow dr in ds.Tables[0].Rows
                           select new ArbolAtributos
                           {
                               Ok = int.Parse(dr["Ok"].ToString()),
                               PrefId = dr["PRF_Id"].ToString(),
                               Nivel = int.Parse(dr["Nivel"].ToString()),
                               Prefijo = dr["Prefijo"].ToString(),
                               Grupo = dr["Grupo"].ToString(),
                               AtdId = int.Parse(dr["ATD_Id"].ToString()),
                               Atributo = dr["Atributo"].ToString(),
                               Stock = int.Parse(dr["Stock"].ToString()),
                               Disponible = int.Parse(dr["Disponible"].ToString()),
                               EsLinea = dr["EsLinea"].ToString(),
                               Orden = int.Parse(dr["Orden"].ToString()),
                               FotoPrefijo = dr["FotoPrefijo"].ToString(),
                               FotoArbol = dr["FotoArbol"].ToString(),
                               Tipo = int.Parse(dr["Tipo"].ToString())
                           }).ToList();

            return listado.ToList();
        }

        public List<ArbolMasComprados> WPL_Sku_Atributos_MasComprados(string tipo, char stock, char disponible,
            string empresa,
            string prefijo, float nroskus, int tieId, string arbol,
            int arbolNivel, string mbArtNom, string mbFamCod, string mbClaCod, string mbMerCod, string mbGrpCod,
            string prfId, string bodega, string busquedaExacta,
            int skuActivo, string fechaDesde, string fechaHasta, int idAtrCliente, string codPromo)
        {
            var ds = DbGeneral.WPL_Sku_Atributos(tipo, stock, disponible, empresa, prefijo, nroskus, tieId, arbol, arbolNivel, mbArtNom, mbFamCod, mbClaCod, mbMerCod, mbGrpCod, prfId, bodega, busquedaExacta, skuActivo, fechaDesde, fechaHasta, idAtrCliente, codPromo);
            var listado = (from DataRow dr in ds.Tables[0].Rows
                           select new ArbolMasComprados
                           {
                               SkuId = int.Parse(dr["SKU_Id"].ToString()),
                               Sku = dr["SKU"].ToString(),
                               NombreSku = dr["NombreSku"].ToString(),
                               Stock = dr["Stock"].ToString(),
                               Lista = int.Parse(dr["Lista"].ToString()),
                               PrecioUnidad = double.Parse(dr["PrecioUnidad"].ToString()),
                               FactorUm = dr["FactorUM"].ToString(),
                               Um = dr["UM"].ToString(),
                               Precio = double.Parse(dr["Precio"].ToString()),
                               Foto = dr["Foto"].ToString()
                           }).ToList();

            return listado.ToList();
        }


        public List<ArbolProductos> WPL_Sku_Atributos_Productos(string tipo, char stock, char disponible, string empresa, string prefijo, float nroskus, int tieId, string arbol,
            int arbolNivel, string mbArtNom, string mbFamCod, string mbClaCod, string mbMerCod, string mbGrpCod, string prfId, string bodega, string busquedaExacta,
            int skuActivo, string fechaDesde, string fechaHasta, int idAtrCliente, string codPromo)
        {
            var ds = DbGeneral.WPL_Sku_Atributos(tipo, stock, disponible, empresa, prefijo, nroskus, tieId, arbol, arbolNivel, mbArtNom, mbFamCod, mbClaCod, mbMerCod, mbGrpCod, prfId, bodega, busquedaExacta, skuActivo, fechaDesde, fechaHasta, idAtrCliente, codPromo);
            var total = ds.Tables[0].Rows.Count;
            var listado = (from DataRow dr in ds.Tables[0].Rows
                           select new ArbolProductos
                           {
                               Activo = int.Parse(dr["Activo"].ToString()),
                               SkuId = int.Parse(dr["SKU_Id"].ToString()),
                               Sku = dr["Sku"].ToString(),
                               NombreSku = dr["NombreSku"].ToString(),
                               NombreWeb = dr["NombreWeb"].ToString(),
                               Stock = dr["Stock"].ToString(),
                               Disponible = int.Parse(dr["Disponible"].ToString()),
                               Lista = int.Parse(dr["Lista"].ToString()),
                               PrecioUnidad = double.Parse(dr["PrecioUnidad"].ToString()),
                               PrecioUnidadBruto = double.Parse(dr["PrecioUnidadBruto"].ToString()),
                               FactorUm = int.Parse(dr["FactorUM"].ToString()),
                               Um = dr["UM"].ToString(),
                               Unidades = int.Parse(dr["Unidades"].ToString()),
                               Precio = double.Parse(dr["Precio"].ToString()),
                               PrecioBruto = double.Parse(dr["PrecioBruto"].ToString()),
                               Iva = double.Parse(dr["Iva"].ToString()),
                               Foto = dr["Foto"].ToString(),
                               TotalProductos = total
                           }).ToList();

            return listado.ToList();
        }

        public List<FichaProducto> WPL_Sku_Atributos_Ficha(string prefijo, int tieId, string codPromo)
        {
            var xx = DbGeneral.GetSkuId(prefijo);
            var ds = DbGeneral.WPL_Sku_Atributos("FCH", 'X', 'N', "STE", prefijo, 1, tieId, "", 1, "", "50", "2", "0", "0", "", "", "", 1, "", "", 0, codPromo);
            var listado = (from DataRow dr in ds.Tables[0].Rows
                           select new FichaProducto
                           {
                               Tipo = dr["Tipo"].ToString(),
                               Texto = dr["Texto"].ToString(),
                               Grupo = dr["Grupo"].ToString(),
                               Atributo = dr["Atributo"].ToString(),
                               Flag = int.Parse(dr["Flag"].ToString()),
                               Mensaje = dr["Mensaje"].ToString(),
                               SkuId = xx
                           }).ToList();

            return listado.ToList();
        }

        public RegistroUserModel RegistraUsuarioNatural(string rut, string dv, string clave, string nombre, string apeP, string apeM,
            string eMail, string telefono, string celular, string fax, string sitioWeb)
        {
            var _CodigoPersonaNatural = 1;
            var _ListaPrecioVentasDefecto = 500;
            var _ListaPrecioArriendoDefecto = 100;
            var _ListaPrecioReposicion = 20;
            var nombrecompleto = nombre + " " + apeP + " " + apeM;

            var ds = DbGeneral.WPL_POW_Usuarios("AUS", rut, dv, Helper.Encripta(clave), 2, rut, "", nombre, apeP, apeM,
                nombrecompleto, eMail, telefono, celular, fax, sitioWeb, "N", "N", 1, 0);
            var dr = ds.Tables[0].Rows[0];
            var info = new RegistroUserModel
            {
                Flag = dr["Flag"].ToString(),
                Mensaje = dr["Mensaje"].ToString(),
                Usr_Id = int.Parse(dr["USR_Id"].ToString())
            };

            var dsN = DbGeneral.WS_AGREGA_CLIENTE("STE", rut, dv, nombrecompleto, nombrecompleto, _CodigoPersonaNatural, _ListaPrecioVentasDefecto, _ListaPrecioArriendoDefecto, _ListaPrecioReposicion, 15, "P");


            return info;
        }

        public RegistroUserModel RegistraContacto(string rut, string nomcontacto, string fono, string email)
        {
            var ds = DbGeneral.WS_AGREGA_CONTACTO("STE", rut, nomcontacto, "COB", fono, "0", email, "V", "56", "1");

            var info = new RegistroUserModel
            {
                Flag = "1",
                Mensaje = "OK",
                Usr_Id = 0
            };

            return info;
        }

        public RegistroUserModel RegistraDireccion(string rut, string direccion, string codregion, string codciudad,
            string codcomuna)
        {
            var ds = DbGeneral.WS_AGREGA_DIRECCION("STE", rut, direccion, codregion, codciudad, codcomuna, "0");
            var info = new RegistroUserModel
            {
                Flag = "1",
                Mensaje = "OK",
                Usr_Id = 0
            };

            return info;
        }

        public FichaUsuarioModel FichaCliente(string rut)
        {
            var ds0 = DbGeneral.WPL_POW_Usuarios("FUS",rut,"","",0,"","","","","","","","","","","","","",0,0);
            var dr0 = ds0.Tables[0].Rows[0];
            var respuesta = new UsuarioWeb
            {
                Flag = dr0["Flag"].ToString(),
                Id = dr0["Id"].ToString(),
                Rut = dr0["Rut"].ToString(),
                Dv = dr0["Dv"].ToString(),
                RazonSocial = dr0["RazonSocial"].ToString(),
                Fantasia = dr0["Fantasia"].ToString(),
                Nombre = dr0["Nombre"].ToString(),
                ApeP = dr0["ApeP"].ToString(),
                ApeM = dr0["ApeM"].ToString(),
                Email = dr0["EMail"].ToString(),
                Telefono = dr0["Telefono"].ToString(),
                Celular = dr0["Celular"].ToString(),
                Fax = dr0["Fax"].ToString(),
                SitioWeb = dr0["SitioWeb"].ToString(),
                EsEmpresa = dr0["EsEmpresa"].ToString(),
                EsFactura = dr0["EsFactura"].ToString()
            };


            var ds1 = DbGeneral.WS_CONSULTA_CLIENTE("STE", rut, 1);
            var ds2 = DbGeneral.WS_CONSULTA_CLIENTE("STE", rut, 2);
            var ds3 = DbGeneral.WS_CONSULTA_CLIENTE("STE", rut, 3);

            var dr = ds1.Tables[0].Rows[0];
            var info = new FichaUsuarioModel();
            var lst2 = ds2.Tables[0].ToList<FichaUsuarioDireccion>();


            var itemToRemove = lst2.Single(r => r.MbDirCod == "777");
            lst2.Remove(itemToRemove);

            var lst3 = ds3.Tables[0].ToList<FichaUsuarioContacto>();
            info.Contactos = lst3;
            info.Direcciones = lst2;
            info.UsuarioWeb = respuesta;
            info.MbAuxCod = dr["MbAuxCod"].ToString();
            info.MbAuxDv = dr["MbAuxDv"].ToString();
            info.MbAuxRaz = dr["MbAuxRaz"].ToString();
            info.MbGirDes = dr["MbGirDes"].ToString();
            info.GcCliBod = dr["GcCliBod"].ToString();
            
            return info;
        }
       

        public FichaTotales CalculoTotales(string prefijos, string arbolId, string idRegion, string idCIudad,
            string rutCliente, string codPromo)
        {
            //Dim ds As DataSet = ws.WPL_Sku_Atributos("TOT", "X", "N", "STE", prefijo, 0, arbolid, "", "1", "", region, ciudad, "", "0", "0", rutCliente, "N", 0, "", "", 0, codpromo)

            var ds = DbGeneral.WPL_Sku_Atributos("TOT", 'X', 'N', "STE", prefijos, 0, int.Parse(arbolId), "", 1, "",
                idRegion, idCIudad, "", "0", "0", rutCliente, "N", 0, "", "", 0, codPromo);

            var info = new FichaTotales();
            var total = new Totales();
            var detalle = new List<Detalle>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["Tipo"].ToString().Equals("C"))
                {
                    total.Unidades = dr["Unidades"].ToString();
                    total.PrecioNeto = dr["PrecioNeto"].ToString();
                    total.Precio = dr["Precio"].ToString();
                    total.TotalCompra = dr["TotalCompra"].ToString();
                    total.PrecioBruto = dr["PrecioBruto"].ToString();
                    total.Iva = dr["Iva"].ToString();
                    total.IvaDespacho = dr["IvaDespacho"].ToString();
                    total.IvaFlete = dr["IvaFlete"].ToString();
                    total.Flete = dr["Flete"].ToString();
                    total.FleteBruto = dr["FleteBruto"].ToString();
                    total.Lista = dr["Lista"].ToString();
                }
                else if (dr["Tipo"].ToString().Equals("D"))
                {
                    detalle.Add(new Detalle
                    {
                        SkuId = dr["SKU_Id"].ToString(),
                        Sku = dr["Sku"].ToString(),
                        NombreSku = dr["NombreSku"].ToString(),
                        NombreSkuCorto = dr["NombreSkuCorto"].ToString(),
                        Stock = dr["Stock"].ToString(),
                        Disponible = dr["Disponible"].ToString(),
                        Lista = dr["Lista"].ToString(),
                        PrecioUnidad = dr["PrecioUnidad"].ToString(),
                        PrecioUnidadBruto = dr["Unidades"].ToString(),
                        Um = dr["UM"].ToString(),
                        FactorUm = dr["FactorUM"].ToString(),
                        PrecioUm = dr["PrecioUM"].ToString(),
                        PrecioUMBruto = dr["PrecioUMBruto"].ToString(),
                        Unidades = dr["Unidades"].ToString(),
                        UnidadesLisa = dr["UnidadesLisa"].ToString(),
                        Precio = dr["Precio"].ToString(),
                        PrecioNeto = dr["PrecioNeto"].ToString(),
                        TotalCompra = dr["TotalCompra"].ToString(),
                        PrecioBruto = dr["PrecioBruto"].ToString(),
                        Iva = dr["Iva"].ToString(),
                        Foto = dr["Foto"].ToString()
                    });
                }
            }
            info.Totales = total;
            info.DetalleSku = detalle;
            return info;
        }

        public XmlElement GeneralVentaXml(string rutCliente, string skuValidos, string idDespacho, string idFacturacion, string arbolId, string idRegion, string idCiudad, string codPromo)
        {
            var au = new List<Articulo>();
            

            var info = CalculoTotales(skuValidos, arbolId, idRegion, idCiudad, rutCliente, codPromo);

            var rut = rutCliente;
            var recargo = "N";
            if (info.Totales.Flete != "0")
                recargo = "S";
            var neto = info.Totales.PrecioNeto;
            var listaprecio = info.Totales.Lista;
            var dirdespacho = idDespacho;
            var dirfacturacion = idFacturacion;


            var rowx = 0;
            foreach (var t in info.DetalleSku)
            {
                if (rowx == 0)
                {
                    au.Add(new Articulo
                    {
                        ArticuloCod = t.Sku, 
                        UsoEnvase = String.Empty,
                        Preciovta = t.PrecioNeto,
                        Dscto_Linea  = "0.00",
                        Dscto_Linea1 = "0.00",
                        Dscto_Linea2 = "0.00",
                        Dscto_Linea3 = "0.00",
                        Umevta_Cant = t.Unidades,
                        Umevta = t.Um,
                        Linea_OC_Cli = String.Empty,
                        Comision = "0.00",
                        Flete = info.Totales.Flete
                    });
                }
                else
                {
                    au.Add(new Articulo
                    {
                        ArticuloCod = t.Sku,
                        UsoEnvase = String.Empty,
                        Preciovta = t.PrecioNeto,
                        Dscto_Linea = "0.00",
                        Dscto_Linea1 = "0.00",
                        Dscto_Linea2 = "0.00",
                        Dscto_Linea3 = "0.00",
                        Umevta_Cant = t.Unidades,
                        Umevta = t.Um,
                        Linea_OC_Cli = String.Empty,
                        Comision = "0.00",
                        Flete = "0"
                    });
                }

                rowx++;
            }


            var xx = new NotaPedido
            {
                Empresa = "STE",
                Fecha_Emision = DateTime.Now.ToString("yyyy-MM-dd"),
                Fecha_Despacho = DateTime.Now.ToString("yyyy-MM-dd"),
                Fecha_Orden = DateTime.Now.ToString("yyyy-MM-dd"),
                Usuario = "WSERVICE",
                VolumDscto_NP = String.Empty,
                PorcDscto_Pago = "0",
                PorcDscto_Especial = "0",
                Recargo = recargo, //S o N
                FormaFacturar_NP = "P",
                Indica_UsoTcambio = "2",
                Lprecio_Paridad = "1",
                Paridad = "1",
                Pagado = "T",
                SucursalCliente = "0001",
                Obs_NotaPedido = rut,
                MontoNeto_NP = neto,
                MontoExento_NP = "0",
                Sede = "1",
                CentroGestion_NP = "120403",
                Vendedor = "WWW",
                Lprecio = listaprecio,
                Auxiliar = rut,
                Contacto = "1",
                Dir_Despacho = dirdespacho,
                Direccion_Factura = dirfacturacion,
                Bodega = "7",
                Departamento = "200",
                Moneda = "CLP",
                Tipodespacho_NP = "99",
                Tipo_transporte = "2",
                Concepto_Venta = "15",
                Termino_Pago = "26",
                OrdenCompra = String.Empty,
                Articulos = au
            };


            var xmlSerializer = new XmlSerializer(typeof(NotaPedido), "LisaWs70");
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, "LisaWs70");
            
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, xx, ns);
            
           

           var doc = new XmlDocument();
           doc.LoadXml(stringWriter.ToString());
           return doc.DocumentElement;
        }

        public NotaVentaModel GeneralVentaNotaPedido(string rutCliente, string skuValidos,string arbolId, string idRegion, string idCiudad)
        {
            var mensaje = "";
            var nventa = "";
            var continua = true;

            if(skuValidos == String.Empty)
            {
                mensaje = "SkuId vacio";
                nventa = "0";
                continua = false;
            }

            if (!skuValidos.Contains("|"))
            {
                mensaje = "SkuId incorrecto";
                nventa = "0";
                continua = false;
            }
            
            if(continua == true)
            {
                var info = CalculoTotales(skuValidos, arbolId, idRegion, idCiudad, rutCliente, "");
                var ds1 = DbGeneral.POS_ActualizaCabecera("N", "STE", "7", "99", "NV", "0",
                    DateTime.Now.ToString("dd/MM/yyyy"), "WWWW", rutCliente, info.Totales.Lista, "2", "0", "0", "0", "0",
                    "0", "0", "0", "0", "", "0", "0", "1", "", "0", "0", "0", "0", "0", "0", "");
                var dr = ds1.Tables[0].Rows[0];
                nventa = dr["Ok"].ToString();
                mensaje = dr["Glosa"].ToString();



                foreach (var t in info.DetalleSku)
                {
                    var ds2 = DbGeneral.POS_ActualizaDetalle("N", "STE", "7", "99", "NV", nventa, t.Sku, t.Um, t.Unidades,
                        "", "", "", t.PrecioNeto, "");
                } 
            }

            
            var data = new NotaVentaModel
            {
                Glosa = mensaje,
                Ok = nventa
            };

            return data;
        }


        public NotaVentaModel FinalizaVenta(string nVenta, string rutCliente, string skuValidos, string idDespacho, string idFacturacion, string arbolId, string idRegion, string idCiudad, string codPromo,
            string tbkAutorizacion, string tbkTarjeta, string tbkTipoPago, string tbkCuotas)
        {
            var texto = "";
            var valor = "";
            try
            {
                var aa = GeneralVentaXml(rutCliente, skuValidos, idDespacho, idFacturacion, arbolId, idRegion, idCiudad,
               codPromo);

                var datexml = DateTime.Now.ToString("yyyyMMdd HHmmss");
                var s = aa.OuterXml;
                var xdoc = new XmlDocument();
                xdoc.LoadXml(s);
                xdoc.Save(string.Format(@"c:\xml\{0}_{1}.xml", nVenta, datexml));
                texto = "Venta Finalizada, xml generado";
                valor = "1";
            }
            catch (Exception e)
            {

                texto = e.ToString();
                valor = "-1";
            }
           

            //TBK_CODIGO_AUTORIZACION = codigo autorizacion
            //TBK_FINAL_NUMERO_TARJETA = digitos tarjeta
            //TBK_TIPO_PAGO = tipo de compra
            //TBK_NUMERO_CUOTAS = nº cuotas


            var data = new NotaVentaModel
            {
                Glosa = texto,
                Ok = valor
            };

            return data;
        }

        public List<GruposModel> TraeGrupos(int tieId, string arbol, string prfId)
        {
            var ds = DbGeneral.WPL_Sku_Atributos("SPP", 'X', 'N', "STE", "", 1, tieId, arbol, 2, "", "", "", "", "0",
                prfId, "", "N", 1, "", "", 0, "");

            var lst = ds.Tables[0].ToList<GruposModel>();

            return lst;
        }


        public List<GrupoListModel> TraeGrupoAtributo(int tieId, string arbol, string prfId)
        {
            var ds = DbGeneral.WPL_Sku_Atributos("SPP", 'X', 'N', "STE", "", 1, tieId, arbol, 2, "", "", "", "", "0",
                prfId, "", "N", 1, "", "", 0, "");

            var lst = ds.Tables[0].ToList<GruposModel>();

            return (from t in lst
                let ds2 = DbGeneral.WPL_Sku_Atributos("SPP", 'X', 'N', "STE", "", 1, tieId, arbol, 2, "", "", "", "", "0", prfId, t.Grp_Id, "N", 1, "", "", 0, "")
                let lst2 = ds2.Tables[0].ToList<AtributosModel>()
                let pp2 = lst2.Select<AtributosModel, AtributosModel>(i => new AtributosModel {Atributo = ToTitleCase(i.Atributo), Grp_Id = i.Grp_Id, Prefijo = i.Prefijo, Grupo = i.Grupo}).ToList()
                select new GrupoListModel
                {
                    Prefijo = t.Prefijo, Grupo = t.Grupo, Grp_Id = t.Grp_Id, Atributos = pp2
                }).ToList();
        }

        public string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public List<AtributosModel> TraeAtributos(int tieId, string arbol, string prfId, string grpId)
        {
            var ds = DbGeneral.WPL_Sku_Atributos("SPP", 'X', 'N', "STE", "", 1, tieId, arbol, 2, "", "", "", "", "0",
                prfId, grpId, "N", 1, "", "", 0, "");

            var lst = ds.Tables[0].ToList<AtributosModel>();

            return lst;
        }

        public ValidaStockModel ValidaSku(int tieId, string sku)
        {
            var ds = DbGeneral.WPL_Sku_Atributos("VAL", 'X', 'N', "STE", sku, 1, tieId, "", 2, "", "", "", "", "0",
                "", "", "N", 1, "", "", 0, "");
            var dr = ds.Tables[0].Rows[0];
            var info = new ValidaStockModel
            {
                Flag = dr["Flag"].ToString(),
                Unidades = dr["Unidades"].ToString(),
                UnidadesTotales = dr["UnidadesTotales"].ToString(),
                StockDisponible = dr["StokDisponible"].ToString(),
                Mensaje = dr["Mensaje"].ToString()
            };

            return info;
        }


        


        [XmlRoot(ElementName = "NotaPedido")]
        public class NotaPedido
        {
            public string Empresa { get; set; }
            public string Fecha_Emision { get; set; }
            public string Fecha_Despacho { get; set; }
            public string Fecha_Orden { get; set; }
            public string Usuario { get; set; }
            public string VolumDscto_NP { get; set; }
            public string PorcDscto_Pago { get; set; }
            public string PorcDscto_Especial { get; set; }
            public string Recargo { get; set; }
            public string FormaFacturar_NP { get; set; }
            public string Indica_UsoTcambio { get; set; }
            public string Lprecio_Paridad { get; set; }
            public string Paridad { get; set; }
            public string Pagado { get; set; }
            public string SucursalCliente { get; set; }
            public string Obs_NotaPedido { get; set; }
            public string MontoNeto_NP { get; set; }
            public string MontoExento_NP { get; set; }
            public string Sede { get; set; }
            public string CentroGestion_NP { get; set; }
            public string Vendedor { get; set; }
            public string Lprecio { get; set; }
            public string Auxiliar { get; set; }
            public string Contacto { get; set; }
            public string Dir_Despacho { get; set; }
            public string Direccion_Factura { get; set; }
            public string Bodega { get; set; }
            public string Departamento { get; set; }
            public string Moneda { get; set; }
            public string Tipodespacho_NP { get; set; }
            public string Tipo_transporte { get; set; }
            public string Concepto_Venta { get; set; }
            public string Termino_Pago { get; set; }
            public string OrdenCompra { get; set; }

            public List<Articulo> Articulos = new List<Articulo>();
        }

        public class Articulo
        {
            public string ArticuloCod { get; set; }
            public string UsoEnvase { get; set; }
            public string Preciovta { get; set; }
            public string Dscto_Linea { get; set; }
            public string Dscto_Linea1 { get; set; }
            public string Dscto_Linea2 { get; set; }
            public string Dscto_Linea3 { get; set; }
            public string Umevta_Cant { get; set; }
            public string Umevta { get; set; }
            public string Linea_OC_Cli { get; set; }
            public string Comision { get; set; }
            public string Flete { get; set; }
        }

      
    }
}