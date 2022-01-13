using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DataTableSearch
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }
    public class DataTableOrder
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }
    public class DataTableColumn
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public DataTableSearch Search { get; set; }
    }
    public class DataTableRequestDto<TEntity>
        where TEntity : IDto, new()
    {
        public List<DataTableColumn> Columns { get; set; }
        public int Draw { get; set; }
        public int Length { get; set; }
        public int Start { get; set; }
        public DataTableSearch Search { get; set; }
        public List<DataTableOrder> Order { get; set; }
        public TEntity GetEntity()
        {
            TEntity entity = new TEntity();
            if (this.Search.Value == "")
                return entity;
            foreach (PropertyInfo item in entity.GetType().GetProperties())
            {
                foreach (var column in this.Columns)
                {
                    if (column.Data.ToLower() == item.Name.ToLower())
                    {
                        try
                        {
                            switch (item.PropertyType.Name)
                            {
                                case "Boolean":
                                    entity.GetType().GetProperty(item.Name).SetValue(entity, Convert.ToBoolean(this.Search.Value), null);
                                    break;
                                case "Int32":
                                    entity.GetType().GetProperty(item.Name).SetValue(entity, Convert.ToInt32(this.Search.Value), null);
                                    break;
                                case "Decimal":
                                    entity.GetType().GetProperty(item.Name).SetValue(entity, Convert.ToDecimal(this.Search.Value), null);
                                    break;
                                default:
                                    entity.GetType().GetProperty(item.Name).SetValue(entity, this.Search.Value, null);
                                    break;
                            }
                        }
                        catch (Exception)
                        {
                        }

                    }
                }

            }
            return entity;
        }
    }
    public class DataTableResultDto<TEntity>
        where TEntity : IDto
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public List<TEntity> Data { get; set; }
    }
}
