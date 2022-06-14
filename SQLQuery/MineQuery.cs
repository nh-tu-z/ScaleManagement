using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//
using scale.Helper;
using scale.Model;
// debugging
using System.Diagnostics;

namespace scale.SQLQuery
{
    class MineQuery
    {
        private static readonly string DEFAULT_STRING = "N/A";
        // CREATE
        public static int CreateClient(Client newClient)
        {
            int rowCount;

            if(!ValidateClient(ref newClient))
            {
                return 0;
            }

            try
            {
                // Query.
                string query = $@"INSERT INTO dbo.KhachHang (ID, Name, SDT, DiaChi, GhiChu)
                                  VALUES('{newClient.ID}','{newClient.Name}','{newClient.Phone}','{newClient.Address}','{newClient.Note}')";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                rowCount = SQLCommand.executeInsert(query, ref dBConnection);

                // debugging
                Trace.WriteLine($"CreateClient - Created row: {rowCount}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowCount;
        }
        public static int CreateUnitPrice(UnitPrice newUnitPrice)
        {
            int rowCount;

            if(!ValidateUnitPrice(ref newUnitPrice))
            {
                return 0;
            }

            try
            {
                // Query.
                string query = $@"INSERT INTO dbo.DonGia (SanPhamID, Ngay, TyTrong, Gia, GhiChu)
                                  VALUES('{newUnitPrice.ProductID}','{newUnitPrice.Date}','{newUnitPrice.Proportion}','{newUnitPrice.Price}','{newUnitPrice.Note}')";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                rowCount = SQLCommand.executeInsert(query, ref dBConnection);

                // debugging
                Trace.WriteLine($"createUnitPrice - Created row: {rowCount}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowCount;
        }
        public static int CreateProduct(Product newProduct)
        {
            int rowCount;
            try
            {
                // Query.
                string query = $@"INSERT INTO dbo.SanPham (ID, Name, GhiChu)
                                  VALUES('{newProduct.ID}','{newProduct.Name}','{newProduct.Note}')";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                rowCount = SQLCommand.executeInsert(query, ref dBConnection);

                // debugging
                Trace.WriteLine($"createProduct - Created row: {rowCount}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowCount;
        }

        // READ
        public static List<OutputSheet> GetOutputSheets()
        {
            List<OutputSheet> outputSheetList = new List<OutputSheet>();
            try
            {
                // Query.  
                string query = @"SELECT TOP 20 
                                      sheet.SoPhieu, sheet.SoXe, client.Name, 
                                      price.TyTrong, price.Gia,
                                      sheet.TrongLuongVao, sheet.TrongLuongRa, sheet.TienVanChuyen, 
                                      sheet.GioVao, sheet.GioRa, sheet.GhiChu 
                                 FROM dbo.PhieuCan AS sheet 
                                 JOIN dbo.KhachHang AS client ON sheet.KhachHangID = client.ID 
                                 JOIN dbo.DonGia AS price ON sheet.SanPhamID = price.SanPhamID";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                SqlDataReader dataReader = SQLCommand.executeSelect(query, ref dBConnection);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        OutputSheet outputSheet = new OutputSheet();

                        // not null fields
                        outputSheet.SheetID = dataReader.GetString(0);
                        outputSheet.TruckNumber = dataReader.GetString(1);
                        outputSheet.Client = dataReader.GetString(2);
                        outputSheet.Exchange = dataReader.GetDouble(3).ToString();
                        outputSheet.UnitPrice = dataReader.GetDouble(4).ToString();
                        outputSheet.Price = " ???";

                        // SQL Float  <=> C# Double
                        outputSheet.WeightIn = dataReader.GetDouble(5).ToString();
                        outputSheet.WeightOut = dataReader.GetDouble(6).ToString();
                        outputSheet.MerchandiseWeight = (dataReader.GetDouble(6) - dataReader.GetDouble(5)).ToString();
                        outputSheet.Ship = dataReader.GetDouble(7).ToString();

                        // SQL time <=> C# time span
                        outputSheet.TimeIn = dataReader.GetTimeSpan(8).ToString();

                        // null fields
                        outputSheet.TimeOut = dataReader.IsDBNull(9) ? "Null" : dataReader.GetTimeSpan(9).ToString();
                        outputSheet.Note = dataReader.IsDBNull(10) ? "Null" : dataReader.GetString(10).ToString();

                        outputSheetList.Add(outputSheet);

                        // debugging
                        Trace.WriteLine($"ID: {outputSheet.SheetID} - Truck Number: {outputSheet.TruckNumber} - Client: {outputSheet.Client}");

                        Trace.WriteLine($"Exchange: {outputSheet.Exchange} - Unit Price: {outputSheet.UnitPrice} - Price: {outputSheet.Price}");

                        Trace.WriteLine($"Weight In: {outputSheet.WeightIn} - Weight Out: {outputSheet.WeightOut} - Ship: {outputSheet.Ship}");

                        Trace.WriteLine($"Merchandise weight: {outputSheet.MerchandiseWeight}");

                        Trace.WriteLine($"Time In: {outputSheet.TimeIn} - Time Out: {outputSheet.TimeOut} - Note: {outputSheet.Note}");
                    }
                }

                dBConnection.connection().Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return outputSheetList;
        }

        // get output sheet for a specific day
        public static List<OutputSheet> GetOutputSheetForSpecificDay(DateTime date)
        {
            // debugging
            Trace.WriteLine($"GetOutputSheetForSpecificDay - Day: {date.Date.ToString("yyyy/dd/MM")}");

            List<OutputSheet> outputSheetList = new List<OutputSheet>();
            try
            {
                // Query.  
                string query = $@"SELECT sheet.SoPhieu, sheet.SoXe, client.Name,  
                                        price.TyTrong, price.Gia,
                                        sheet.TrongLuongVao, sheet.TrongLuongRa, sheet.TienVanChuyen, 
                                        sheet.GioVao, sheet.GioRa, sheet.GhiChu 
                                 FROM dbo.PhieuCan AS sheet 
                                 JOIN dbo.KhachHang AS client ON sheet.KhachHangID = client.ID 
                                 JOIN dbo.DonGia AS price ON sheet.SanPhamID = price.SanPhamID
                                 WHERE sheet.Ngay='{date.Date.ToString("yyyy/dd/MM")}'";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                SqlDataReader dataReader = SQLCommand.executeSelect(query, ref dBConnection);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        OutputSheet outputSheet = new OutputSheet();

                        // not null fields
                        outputSheet.SheetID = dataReader.GetString(0);
                        outputSheet.TruckNumber = dataReader.GetString(1);
                        outputSheet.Client = dataReader.GetString(2);
                        outputSheet.Exchange = dataReader.GetDouble(3).ToString();
                        outputSheet.UnitPrice = dataReader.GetDouble(4).ToString();
                        outputSheet.Price = " ???";

                        // SQL Float  <=> C# Double
                        outputSheet.WeightIn = dataReader.GetDouble(5).ToString();
                        outputSheet.WeightOut = dataReader.GetDouble(6).ToString();
                        outputSheet.MerchandiseWeight = (dataReader.GetDouble(6) - dataReader.GetDouble(5)).ToString();
                        outputSheet.Ship = dataReader.GetDouble(7).ToString();

                        // SQL time <=> C# time span
                        outputSheet.TimeIn = dataReader.GetTimeSpan(8).ToString();

                        // null fields
                        outputSheet.TimeOut = dataReader.IsDBNull(9) ? "Null" : dataReader.GetTimeSpan(9).ToString();
                        outputSheet.Note = dataReader.IsDBNull(10) ? "Null" : dataReader.GetString(10).ToString();

                        outputSheetList.Add(outputSheet);

                        // debugging
                        Trace.WriteLine($"ID: {outputSheet.SheetID} - Truck Number: {outputSheet.TruckNumber} - Client: {outputSheet.Client}");

                        Trace.WriteLine($"Exchange: {outputSheet.Exchange} - Unit Price: {outputSheet.UnitPrice} - Price: {outputSheet.Price}");

                        Trace.WriteLine($"Weight In: {outputSheet.WeightIn} - Weight Out: {outputSheet.WeightOut} - Ship: {outputSheet.Ship}");

                        Trace.WriteLine($"Merchandise weight: {outputSheet.MerchandiseWeight}");

                        Trace.WriteLine($"Time In: {outputSheet.TimeIn} - Time Out: {outputSheet.TimeOut} - Note: {outputSheet.Note}");
                    }
                }

                dBConnection.connection().Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return outputSheetList;
        }

        // get output sheets from one day to another day
        public static List<OutputSheet> GetOutputSheetForDays(DateTime fromDate, DateTime toDate)
        {
            // debugging
            Trace.WriteLine($"GetOutputSheetForDays - FROM day: {fromDate.Date.ToString("yyyy/dd/MM")}");
            Trace.WriteLine($"GetOutputSheetForDays - TO day: {toDate.Date.ToString("yyyy/dd/MM")}");

            List<OutputSheet> outputSheetList = new List<OutputSheet>();
            try
            {
                // Query.  
                string query = $@"SELECT sheet.SoPhieu, sheet.SoXe, client.Name,  
                                        price.TyTrong, price.Gia,
                                        sheet.TrongLuongVao, sheet.TrongLuongRa, sheet.TienVanChuyen, 
                                        sheet.GioVao, sheet.GioRa, sheet.GhiChu 
                                 FROM dbo.PhieuCan AS sheet 
                                 JOIN dbo.KhachHang AS client ON sheet.KhachHangID = client.ID 
                                 JOIN dbo.DonGia AS price ON sheet.SanPhamID = price.SanPhamID
                                 WHERE sheet.Ngay BETWEEN '{fromDate.Date.ToString("yyyy/dd/MM")}' AND '{toDate.Date.ToString("yyyy/dd/MM")}'";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                SqlDataReader dataReader = SQLCommand.executeSelect(query, ref dBConnection);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        OutputSheet outputSheet = new OutputSheet();

                        // not null fields
                        outputSheet.SheetID = dataReader.GetString(0);
                        outputSheet.TruckNumber = dataReader.GetString(1);
                        outputSheet.Client = dataReader.GetString(2);
                        outputSheet.Exchange = dataReader.GetDouble(3).ToString();
                        outputSheet.UnitPrice = dataReader.GetDouble(4).ToString();
                        outputSheet.Price = " ???";

                        // SQL Float  <=> C# Double
                        outputSheet.WeightIn = dataReader.GetDouble(5).ToString();
                        outputSheet.WeightOut = dataReader.GetDouble(6).ToString();
                        outputSheet.MerchandiseWeight = (dataReader.GetDouble(6) - dataReader.GetDouble(5)).ToString();
                        outputSheet.Ship = dataReader.GetDouble(7).ToString();

                        // SQL time <=> C# time span
                        outputSheet.TimeIn = dataReader.GetTimeSpan(8).ToString();

                        // null fields
                        outputSheet.TimeOut = dataReader.IsDBNull(9) ? "Null" : dataReader.GetTimeSpan(9).ToString();
                        outputSheet.Note = dataReader.IsDBNull(10) ? "Null" : dataReader.GetString(10).ToString();

                        outputSheetList.Add(outputSheet);

                        // debugging
                        Trace.WriteLine($"ID: {outputSheet.SheetID} - Truck Number: {outputSheet.TruckNumber} - Client: {outputSheet.Client}");

                        Trace.WriteLine($"Exchange: {outputSheet.Exchange} - Unit Price: {outputSheet.UnitPrice} - Price: {outputSheet.Price}");

                        Trace.WriteLine($"Weight In: {outputSheet.WeightIn} - Weight Out: {outputSheet.WeightOut} - Ship: {outputSheet.Ship}");

                        Trace.WriteLine($"Merchandise weight: {outputSheet.MerchandiseWeight}");

                        Trace.WriteLine($"Time In: {outputSheet.TimeIn} - Time Out: {outputSheet.TimeOut} - Note: {outputSheet.Note}");
                    }
                }

                dBConnection.connection().Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // debugging
            Trace.WriteLine($"GetOutputSheetForDays - How many output sheets: {outputSheetList.Count}");

            return outputSheetList;
        }
        public static List<Client> GetClients()
        {
            List<Client> clientList = new List<Client>();
            try
            {
                // Query.  
                string query = @"SELECT client.ID, client.Name, client.SDT, client.DiaChi, client.GhiChu
                                 FROM dbo.KhachHang AS client";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                SqlDataReader dataReader = SQLCommand.executeSelect(query, ref dBConnection);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Client client = new Client();

                        // not null fields
                        client.ID = dataReader.GetString(0);
                        client.Name = dataReader.GetString(1);

                        // null fields
                        client.Phone = dataReader.IsDBNull(2) ? "Null" : dataReader.GetString(2);
                        client.Address = dataReader.IsDBNull(3) ? "Null" : dataReader.GetString(3);
                        client.Note = dataReader.IsDBNull(4) ? "Null" : dataReader.GetString(4);

                        clientList.Add(client);

                        // debugging
                        Trace.WriteLine($"ID: {client.ID} - Name: {client.Name}");

                        Trace.WriteLine($"Phone: {client.Phone} - Address: {client.Address}");
                    }
                }

                dBConnection.connection().Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return clientList;
        }
        public static List<UnitPrice> GetUnitPrices()
        {
            List<UnitPrice> unitPriceList = new List<UnitPrice>();
            try
            {
                // Query.  
                string query = @"SELECT price.SanPhamID, price.Ngay, price.TyTrong, price.Gia, price.GhiChu
                                 FROM dbo.DonGia AS price";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                SqlDataReader dataReader = SQLCommand.executeSelect(query, ref dBConnection);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        UnitPrice unitPrice = new UnitPrice();

                        // not null fields
                        unitPrice.ProductID = dataReader.GetString(0);
                        unitPrice.Date = dataReader.GetDateTime(1).ToString();
                        unitPrice.Proportion = dataReader.GetDouble(2).ToString();
                        unitPrice.Price = dataReader.GetDouble(3).ToString();

                        // null field
                        unitPrice.Note = dataReader.IsDBNull(4) ? "Null" : dataReader.GetString(4);

                        unitPriceList.Add(unitPrice);

                        // debugging
                        Trace.WriteLine($"ProductID: {unitPrice.ProductID} - Date: {unitPrice.Date} - Proportion: {unitPrice.Proportion}");

                        Trace.WriteLine($"Price: {unitPrice.Price} - Note: {unitPrice.Note}");
                    }
                }

                dBConnection.connection().Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return unitPriceList;
        }
        public static List<Product> GetProducts()
        {
            List<Product> productList = new List<Product>();
            try
            {
                // Query.  
                string query = @"SELECT product.ID, product.Name, product.GhiChu
                                 FROM dbo.SanPham AS product";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                SqlDataReader dataReader = SQLCommand.executeSelect(query, ref dBConnection);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Product product = new Product();

                        // not null fields
                        product.ID = dataReader.GetString(0);
                        product.Name = dataReader.GetString(1);

                        // null field
                        product.Note = dataReader.IsDBNull(2) ? "Null" : dataReader.GetString(2);

                        productList.Add(product);

                        // debugging
                        Trace.WriteLine($"ID: {product.ID} - Name: {product.Name} - Note: {product.Note}");
                    }
                }

                dBConnection.connection().Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productList;
        }
        
        // because the product id is string, so when we want to add a new record to dbo.SanPham
        // we need to know the lastest product id in order not to duplicate it
        public static string GetLastProductIDFromProductTable()
        {
            string output = string.Empty;
            try
            {
                // Query.  
                string query = @"SELECT TOP 1 product.ID
                                 FROM dbo.SanPham AS product
                                 ORDER BY product.ID DESC";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                SqlDataReader dataReader = SQLCommand.executeSelect(query, ref dBConnection);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        // not null fields
                        output = dataReader.GetString(0); 

                        // debugging
                        Trace.WriteLine($"GetLastProductIDFromProductTable() - id = {output}");
                    }
                }

                dBConnection.connection().Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return output;
        }

        public static string GetLastProductIDFromUnitPriceTable()
        {
            string output = string.Empty;
            try
            {
                // Query.  
                string query = @"SELECT TOP 1 price.SanPhamID
                                 FROM dbo.DonGia AS price
                                 ORDER BY price.SanPhamID DESC";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                SqlDataReader dataReader = SQLCommand.executeSelect(query, ref dBConnection);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        // not null fields
                        output = dataReader.GetString(0);

                        // debugging
                        Trace.WriteLine($"GetLastProductIDFromUnitPriceTable() - product id = {output}");
                    }
                }

                dBConnection.connection().Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return output;
        }

        // get the last id of client in order to determine the next id for th new client
        public static string GetLastClientIDFromClientTable()
        {
            string output = string.Empty;
            try
            {
                // Query.  
                string query = @"SELECT TOP 1 client.ID
                                 FROM dbo.KhachHang AS client
                                 ORDER BY client.ID DESC";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                SqlDataReader dataReader = SQLCommand.executeSelect(query, ref dBConnection);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        // not null fields
                        output = dataReader.GetString(0);

                        // debugging
                        Trace.WriteLine($"GetLastClientIDFromClientTable() - id = {output}");
                    }
                }

                dBConnection.connection().Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return output;
        }

        // this method gets all fields 'Name' of dbo.KhachHang
        public static List<string> GetClientName()
        {
            List<string> nameList = new List<string>();
            try
            {
                // Query.  
                string query = @"SELECT client.Name
                                 FROM dbo.KhachHang AS client";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                SqlDataReader dataReader = SQLCommand.executeSelect(query, ref dBConnection);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        string name;

                        // not null fields
                        name = dataReader.GetString(0);

                        nameList.Add(name);

                        // debugging
                        Trace.WriteLine($"Name: {name}");
                    }
                }

                dBConnection.connection().Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return nameList;
        }

        // this method gets all fields 'Name' of dbo.SanPham
        public static List<string> GetProductNameFromProductTable()
        {
            List<string> nameList = new List<string>();
            try
            {
                // Query.  
                string query = @"SELECT product.Name
                                 FROM dbo.SanPham AS product";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                SqlDataReader dataReader = SQLCommand.executeSelect(query, ref dBConnection);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        string name;

                        // not null fields
                        name = dataReader.GetString(0);

                        nameList.Add(name);

                        // debugging
                        Trace.WriteLine($"GetProductNameFromProductTable() - Name: {name}");
                    }
                }

                dBConnection.connection().Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return nameList;
        }
        
        // this method gets all fields 'Name' of dbo.DonGia
        // TODO - not complete
        public static List<string> GetProductNameFromPriceTable()
        {
            List<string> nameList = new List<string>();
            try
            {
                // Query.  
                string query = @"SELECT price.SanPhamID
                                 FROM dbo.DonGia AS price";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                SqlDataReader dataReader = SQLCommand.executeSelect(query, ref dBConnection);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        string name;

                        // not null fields
                        name = dataReader.GetString(0);

                        nameList.Add(name);

                        // debugging
                        Trace.WriteLine($"GetProductNameFromPriceTable() - Name: {name}");
                    }
                }

                dBConnection.connection().Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return nameList;
        }

        // because dbo.DonGia.SanPhamID is FK of dbo.SanPham.ID
        // so we need to check for remained product id in order to not be conflict when create new dbo.DonGia record
        public static List<string> GetAvailableProductID()
        {
            List<string> productIDList = new List<string>();
            try
            {
                // Query.  
                string query = @"SELECT product.ID
                                 FROM dbo.DonGia AS price
                                 RIGHT JOIN dbo.SanPham AS product
                                 ON price.SanPhamId = product.ID
                                 WHERE price.SanPhamID IS NULL";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();
                SqlDataReader dataReader = SQLCommand.executeSelect(query, ref dBConnection);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        string productID;

                        // not null fields
                        productID = dataReader.GetString(0);

                        productIDList.Add(productID);

                        // debugging
                        Trace.WriteLine($"GetAvailableProductID() - ProductID: {productID}");
                    }
                }

                dBConnection.connection().Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productIDList;
        }
        // UPDATE
        public static int UpdateClient(Client updateClient)
        {
            int rowCount;
            try
            {
                if (!ValidateClient(ref updateClient))
                {
                    return 0;
                }

                // Query.
                string query = $@"UPDATE dbo.KhachHang
                                  SET Name='{updateClient.Name}', SDT='{updateClient.Phone}', DiaChi='{updateClient.Address}', GhiChu='{updateClient.Note}'
                                  WHERE ID='{updateClient.ID}'";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();

                // TODO - we probably create new SQLCommand.executeUpdate 
                // we use SQLCommand.executeInsert because it has the same behaviour SQLCommand.executeUpdate
                rowCount = SQLCommand.executeInsert(query, ref dBConnection);

                // debugging
                Trace.WriteLine($"UpdateClient - Updated row: {rowCount}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowCount;
        }

        //
        public static int UpdateUnitPrice(UnitPrice changedPriceUnit)
        {
            int rowCount;
            try
            {
                if(!ValidateUnitPrice(ref changedPriceUnit))
                {
                    return 0;
                }

                // Query.
                string query = $@"UPDATE dbo.DonGia
                                  SET Ngay='{changedPriceUnit.Date}', TyTrong='{changedPriceUnit.Proportion}', Gia='{changedPriceUnit.Price}', GhiChu='{changedPriceUnit.Note}'
                                  WHERE SanPhamID='{changedPriceUnit.ProductID}'";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();

                // TODO - we probably create new SQLCommand.executeUpdate 
                // we use SQLCommand.executeInsert because it has the same behaviour SQLCommand.executeUpdate
                rowCount = SQLCommand.executeInsert(query, ref dBConnection);

                // debugging
                Trace.WriteLine($"UpdateUnitPrice - Updated row: {rowCount}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowCount;
        }
        
        //
        public static int UpdateProduct(Product changedProduct)
        {
            int rowCount;
            try
            {
                if (!ValidateProduct(ref changedProduct))
                {
                    return 0;
                }

                // Query.
                string query = $@"UPDATE dbo.SanPham
                                  SET Name='{changedProduct.Name}', GhiChu='{changedProduct.Note}'
                                  WHERE ID='{changedProduct.ID}'";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();

                // TODO - we probably create new SQLCommand.executeUpdate 
                // we use SQLCommand.executeInsert because it has the same behaviour SQLCommand.executeUpdate
                rowCount = SQLCommand.executeInsert(query, ref dBConnection);

                // debugging
                Trace.WriteLine($"UpdateProduct - Updated row: {rowCount}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowCount;
        }

        // DELETE
        public static int deleteClient(Client deleteClient)
        {
            int rowCount;

            try
            {
                // Query.
                string query = $@"DELETE FROM dbo.KhachHang
                                  WHERE ID='{deleteClient.ID}'";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();

                // TODO - we probably create new SQLCommand.executeDelete
                // we use SQLCommand.executeInsert because it has the same behaviour SQLCommand.executeDelete
                rowCount = SQLCommand.executeInsert(query, ref dBConnection);

                // debugging
                Trace.WriteLine($"updateClient - Updated row: {rowCount}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowCount;
        }

        // delete unit price from database
        // \param: ID of product
        public static int DeleteUnitPrice(string productID)
        {
            int rowCount;

            // TODO - validate product id

            try
            {
                // Query.
                string query = $@"DELETE FROM dbo.DonGia
                                  WHERE SanPhamID='{productID}'";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();

                // TODO - we probably create new SQLCommand.executeDelete
                // we use SQLCommand.executeInsert because it has the same behaviour SQLCommand.executeDelete
                rowCount = SQLCommand.executeInsert(query, ref dBConnection);

                // debugging
                Trace.WriteLine($"DeleteUnitPrice - Updated row: {rowCount}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowCount;
        }

        // delete product from database
        // \param: ID of product
        public static int DeleteProduct(string productID)
        {
            int rowCount;

            // TODO - validate product id

            try
            {
                // Query.
                string query = $@"DELETE FROM dbo.SanPham
                                  WHERE ID='{productID}'";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();

                // TODO - we probably create new SQLCommand.executeDelete
                // we use SQLCommand.executeInsert because it has the same behaviour SQLCommand.executeDelete
                rowCount = SQLCommand.executeInsert(query, ref dBConnection);

                // debugging
                Trace.WriteLine($"DeleteProduct - Updated row: {rowCount}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowCount;
        }

        // delete client from database
        // \param: client's ID
        public static int DeleteClient(string clientID)
        {
            int rowCount;

            // TODO - validate product id

            try
            {
                // Query.
                string query = $@"DELETE FROM dbo.KhachHang
                                  WHERE ID='{clientID}'";
                // Execute.  
                DBConnection dBConnection = DBConnection.Instance();

                // TODO - we probably create new SQLCommand.executeDelete
                // we use SQLCommand.executeInsert because it has the same behaviour SQLCommand.executeDelete
                rowCount = SQLCommand.executeInsert(query, ref dBConnection);

                // debugging
                Trace.WriteLine($"DeleteClient - Updated row: {rowCount}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowCount;
        }

        // helper function

        // check for not null field before go into database layer
        private static bool ValidateUnitPrice(ref UnitPrice unitPrice)
        {
            if (string.IsNullOrEmpty(unitPrice.ProductID))
            {
                return false;
            }

            if (string.IsNullOrEmpty(unitPrice.Date))
            {
                // debugging
                Trace.WriteLine($"UpdatePriceUnit - Date is {DateTime.Now.ToString()}");

                unitPrice.Date = DateTime.Now.ToString();
            }

            if (string.IsNullOrEmpty(unitPrice.Proportion))
            {
                unitPrice.Proportion = DEFAULT_STRING;
            }

            if (string.IsNullOrEmpty(unitPrice.Price))
            {
                unitPrice.Price = DEFAULT_STRING;
            }

            return true;
        }

        private static bool ValidateProduct(ref Product product)
        {
            if (string.IsNullOrEmpty(product.ID))
            {
                return false;
            }

            if (string.IsNullOrEmpty(product.Name))
            {
                product.Name = DEFAULT_STRING;
            }

            return true;
        }

        private static bool ValidateClient(ref Client client)
        {
            if(string.IsNullOrEmpty(client.ID))
            {
                return false;
            }

            if(string.IsNullOrEmpty(client.Name))
            {
                return false;
            }

            if(string.IsNullOrEmpty(client.Phone))
            {
                client.Phone = DEFAULT_STRING;
            }

            if(string.IsNullOrEmpty(client.Address))
            {
                client.Address = DEFAULT_STRING;
            }

            return true;
        }
    }
}
