﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCsharpMysql.model
{
    internal class UserCommand
    {
        public bool sucess = false;
        public string messageError = "";
        MySqlConnection conn = new MySqlConnection(ConnectDB.strConn);
        MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader readers;

        public bool Save(string name,string login, string password, string email, string status, string access, string deleted)
        {
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO usuarios(nome, login, senha, email, status, access, deleted) values(@name, @login, @password, @email, @status, @access, @deleted) ";

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@access", access);
                cmd.Parameters.AddWithValue("@deleted", deleted);


                cmd.Prepare();

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                this.messageError = ex.Message;
            }
            catch (Exception ex)
            {
                this.messageError = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            if (messageError.Equals(""))
            {
                sucess = true;
            }
            else
            {
                sucess = false;
            }

            return sucess;
        }
        public MySqlDataReader Read(string search)
        {
            string[] searchRows = { };

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "select * from openxcod.usuarios where nome like @search or login like @search or email like @search ";
                cmd.Parameters.AddWithValue("@search", $"%{search}%");
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();
                readers = reader;
              
            }
            catch (MySqlException ex)
            {
                this.messageError = ex.Message;
            }
            catch (Exception ex)
            {
                this.messageError = ex.Message;
            }



            if (messageError.Equals(""))
            {
                sucess = true;
            }
            else
            {
                sucess = false;
            }

            return readers;
        }
    }
}