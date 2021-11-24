using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppEncomiendasAlexChasi.Models;
using System.Threading.Tasks;

namespace AppEncomiendasAlexChasi.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            //Tabla creada Remitente
            db.CreateTableAsync<modelRemitente>().Wait();

            //Tabla creada Remitente
            db.CreateTableAsync<modelDestinatario>().Wait();


            //Tabla creada Detalle
            db.CreateTableAsync<modelDetalle>().Wait();


            //Tabla creada Transporte
            db.CreateTableAsync<modelTransporte>().Wait();


        }

        //////////////
        ///DETALLE////
        //////////////
        public Task<int> SaveDetalleAsync(modelDetalle detalle)
        {
            if (detalle.IdDetalle != 0)
            {
                return db.UpdateAsync(detalle);
            }
            else
            {
                return db.InsertAsync(detalle);
            }
        }

        //listar detalle
        public Task<List<modelDetalle>> GetDetalleAsync()
        {
            return db.Table<modelDetalle>().ToListAsync();
        }

        //metodo para buscar los detalle por ID
        public Task<modelDetalle> GetDetalleByIdAsync(int idDetalle)
        {
            return db.Table<modelDetalle>().Where(a => a.IdDetalle == idDetalle).FirstOrDefaultAsync();
        }

        //eliminar registros
        public Task<int> DeleteDetalleAsync(modelDetalle deta)
        {
            return db.DeleteAsync(deta);

        }


        ///////////////
        ///TRANSPORTE//
        ///////////////
        public Task<int> SaveTransporteAsync(modelTransporte transporte)
        {
            if (transporte.IdTransporte != 0)
            {
                return db.UpdateAsync(transporte);
            }
            else
            {
                return db.InsertAsync(transporte);
            }
        }

        //listar Transporte
        public Task<List<modelTransporte>> GetTransporteAsync()
        {
            return db.Table<modelTransporte>().ToListAsync();
        }

        //metodo para buscar los destinatario por ID
        public Task<modelTransporte> GetTransporteByIdAsync(int idTransporte)
        {
            return db.Table<modelTransporte>().Where(a => a.IdTransporte == idTransporte).FirstOrDefaultAsync();
        }

        
        //eliminar registros
        public Task<int> DeleteTransporteAsync(modelTransporte trasn)
        {
            return db.DeleteAsync(trasn);

        }



        /////////////////
        ///DESTINATARIO//
        ////////////////
        public Task<int> SaveDestinatarioAsync(modelDestinatario destinatario)
        {
            if (destinatario.IdDestinatario != 0)
            {
                return db.UpdateAsync(destinatario);
            }
            else
            {
                return db.InsertAsync(destinatario);
            }
        }


        //listar registros
        public Task<List<modelDestinatario>> GetDestinatarioAsync()
        {
            return db.Table<modelDestinatario>().ToListAsync();
        }

        //metodo para buscar los destinatario por ID
        public Task<modelDestinatario> GetDestinatarioByIdAsync(int idDestinatario)
        {
            return db.Table<modelDestinatario>().Where(a => a.IdDestinatario == idDestinatario).FirstOrDefaultAsync();
        }

        //eliminar registros
        public Task<int> DeleteDestinatarioAsync(modelDestinatario desti)
        {
            return db.DeleteAsync(desti);

        }




        ///////////////////////
        ///modelo REMITENTE/////
        ////////////////////////

        //guardar registros
        public Task<int> SaveRemitenteAsync(modelRemitente remite)
        {
            if (remite.IdRemitente != 0)
            {
                return db.UpdateAsync(remite);
            }
            else
            {
                return db.InsertAsync(remite);
            }
        }

        //eliminar registros
        public Task<int> DeleteAlumnoAsync(modelRemitente rem)
        {
            return db.DeleteAsync(rem);

        }

        //listar registros
        public Task<List<modelRemitente>> GetRemitenteAsync()
        {
            return db.Table<modelRemitente>().ToListAsync();
        }

        //metodo para buscar los remitentes por ID
        public Task<modelRemitente> GetRemitenteByIdAsync(int idRemitente)
        {
            return db.Table<modelRemitente>().Where(a => a.IdRemitente == idRemitente).FirstOrDefaultAsync();

        }





    }
}
