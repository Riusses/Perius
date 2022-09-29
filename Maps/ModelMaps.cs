using Perius.Models.ViewModels.Clientes;

namespace Perius.Maps
{
    public class ModelMaps
    {
        #region Clientes
        public IQueryable<ClienteViewModel> MapClientes(List<dynamic>? clientes)
        {
            // TODO BLINDAR
            return clientes.Select(x => new ClienteViewModel
            {
                IdCliente = x.IdCliente.Equals(DBNull.Value) ? 0 : (int)x.IdCliente,
                IdTipoDocumento = x.IdTipoDocumento.Equals(DBNull.Value) ? 0 : (int)x.IdTipoDocumento,
                Nombre = x.Nombre.Equals(DBNull.Value) ? string.Empty : (string)x.Nombre,
                PrimerApellido = x.PrimerApellido.Equals(DBNull.Value) ? string.Empty : (string)x.PrimerApellido,
                SegundoApellido = x.SegundoApellido.Equals(DBNull.Value) ? string.Empty : (string)x.PrimerApellido,
                Documento = x.Documento.Equals(DBNull.Value) ? string.Empty : (string)x.Documento,
                FechaAlta = x.FechaAlta.Equals(DBNull.Value) ? DateTime.MinValue : (DateTime)x.FechaAlta,
                FechaBaja = x.FechaBaja.Equals(DBNull.Value) ? null : (DateTime)x.FechaBaja,
                Activo = x.Activo.Equals(DBNull.Value) ? false : (bool)x.Activo,
            }).AsQueryable();
        }
        #endregion
    }
}