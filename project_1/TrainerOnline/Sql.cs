using System.Data.SqlClient;
using DataLayer;

namespace TrainerOnline
{
    internal class sql
    {
        private string cs = File.ReadAllText("../../../Database/cs.txt");
        public sql(string cs)
        {
            this.cs = cs;
        }



        internal List<Company> GetCompany(int id) {
            List<Company> list = new();
            string query = $"select [companyname], [title], [startyear], [endyear] from [trainer_company] where [trainercompanyid] = {id}";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                using SqlCommand newSqlCommand = new(query, conn);
                using SqlDataReader reader = newSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Company()
                    {
                        companyname = reader.GetString(0),
                        title = reader.GetString(1),
                        startdate = reader.GetString(2),
                        enddate = reader.GetString(3),
                    });
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        internal void UpdateCompany(int id, string oldName, string newName, string oldTitle, string newTitle, string oldStartDate, string newStartDate, string oldEndDate, string newEndDate) {
            string query = $"update [trainer_company] set [companyname] = '{newName}', [title] = '{newTitle}', [startyear] = '{newStartDate}', [endyear] = '{newEndDate}' where [companyname] = '{oldName}' and [title] = '{oldTitle}' and [startyear] = '{oldStartDate}' and [endyear] = '{oldEndDate}' and [trainercompanyid] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@company", newName);
                sqlCommand.Parameters.AddWithValue("@title", newTitle);
                sqlCommand.Parameters.AddWithValue("@startdate", newStartDate);
                sqlCommand.Parameters.AddWithValue("@enddate", newEndDate);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"updated...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal void AddCompany(int id, Company company)
        {
            string query = $"insert into [trainer_company] ([companyname], [title], [startyear], [endyear], [trainercompanyid]) values (@company, @title, @startdate, @enddate, @id)";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@company", company.companyname);
                sqlCommand.Parameters.AddWithValue("@title", company.title);
                sqlCommand.Parameters.AddWithValue("@startdate", company.startdate);
                sqlCommand.Parameters.AddWithValue("@enddate", company.enddate);
                sqlCommand.Parameters.AddWithValue("@id", id);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"updated...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal void DeleteCompany(int id, string startyear)
        {
            string query = $"delete [trainer_company] where [startyear] = '{startyear}' and [trainercompanyid] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand newSqlCommand = new(query, conn);
                int rows = newSqlCommand.ExecuteNonQuery();
                Console.WriteLine($"deleted {rows}'s from the table");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }



        internal void UpdateEducation(int id, string oldName, string newName, string oldDegree, string newDegree, string oldGpa, string newGpa, string oldStartDate, string newStartDate, string oldEndDate, string NewEndDate) {
            string query = $"update [trainer_education] set [institute] = '{newName}', [degreename] = '{newDegree}', [gpa] = '{newGpa}', [startdate] = '{newStartDate}', [enddate] = '{NewEndDate}' where [institute] = '{oldName}' and [degreename] = '{oldDegree}' and [gpa] = '{oldGpa}' and [startdate] = '{oldStartDate}' and [enddate] = '{oldEndDate}' and [trainereducationid] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@institute", newName);
                sqlCommand.Parameters.AddWithValue("@degree", newDegree);
                sqlCommand.Parameters.AddWithValue("@gpa", newGpa);
                sqlCommand.Parameters.AddWithValue("@startdate", newStartDate);
                sqlCommand.Parameters.AddWithValue("@enddate", NewEndDate);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"updated...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal void AddEducation(int id, Education education) {
            string query = $"insert into [trainer_education] ([institute], [trainereducationid], [degreename], [gpa], [startdate], [enddate]) values (@institute, @id, @degree, @gpa, @startdate, @enddate)";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@institute", education.institute);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@degree", education.degree);
                sqlCommand.Parameters.AddWithValue("@gpa", education.gpa);
                sqlCommand.Parameters.AddWithValue("@startdate", education.startDate);
                sqlCommand.Parameters.AddWithValue("@enddate", education.endDate);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"updated...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal List<Education> GetEducation(int id) {
            List<Education> newList = new List<Education>();
            string query = $"select [institute], [degreename], [gpa], [startdate], [enddate] from [trainer_education] where [trainereducationid] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                using SqlCommand newSqlCommand = new(query, conn);
                using SqlDataReader reader = newSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    newList.Add(new Education()
                    {
                        institute = reader.GetString(0),
                        degree = reader.GetString(1),
                        gpa = reader.GetString(2),
                        startDate = reader.GetString(3),
                        endDate = reader.GetString(4),
                    });
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return newList;
        }
        internal void DeleteEducation(int id, string startyear)
        {
            string query = $"delete [trainer_education] where [startdate] = '{startyear}' and [trainereducationid] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand newSqlCommand = new(query, conn);
                int rows = newSqlCommand.ExecuteNonQuery();
                Console.WriteLine($"deleted {rows}'s from the table");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }



        internal async Task<List<Skills>> GetAllSkillsAsync(int id)
        {
            List<Skills> newList = new();
            string query = $"select [skill] from [trainer_skill] where [trainerskillid] = {id};";
            using SqlConnection conn = new(cs);
            SqlCommand newSqlCommand = new(query, conn);
            try
            {
                SqlDataReader reader = await newSqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    newList.Add(new Skills(reader.GetString(0))
                    {
                        skillName = reader.GetString(0),
                    });
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            return newList;
        }
        internal List<string> GetAllSkills(int id)
        {
            List<string> newList = new();
            string query = $"select [skill] from [trainer_skill] where [trainerskillid] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand newSqlCommand = new(query, conn);
                SqlDataReader reader = newSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    newList.Add(reader.GetString(0));
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            finally {
                conn.Close();
            }
            return newList;
        }
        internal void AddSkills(Skills skill) {
            string query = "insert into [trainer_skill] ([skill], [trainerskillid]) values (@skill, @trainerskillid);";
            using SqlConnection conn = new(cs);
            try {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@skill", skill.skillName);
                sqlCommand.Parameters.AddWithValue("@trainerskillid", skill.trainerskillid);
                try {
                    int rows = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"{rows} 's added...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal void DeleteSkill(Skills skill) {
            string query = $"delete [trainer_skill] where [skill] = '{skill.skillName}'";
            using SqlConnection conn = new(cs);
            try {
                conn.Open();
                SqlCommand newSqlCommand = new(query, conn);
                int rows = newSqlCommand.ExecuteNonQuery();
                Console.WriteLine($"deleted {rows}'s from the table");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal void UpdateNewSkills(int id, string oldSkill, string newSkill)
        {
            string query = $"update [trainer_skill] set [skill] = '{newSkill}' where [skill] = '{oldSkill}' and [trainerskillid] = {id}";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@skill", newSkill);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"updated...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }



        internal List<Location> GetUserLocation(int id)
        {
            List<Location> newList = new();
            string query = $"select [zipcode], [city] from [trainer_location] where [trainerlocationid] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand newSqlCommand = new(query, conn);
                SqlDataReader reader = newSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    newList.Add(new Location()
                    {
                        zipcode = reader.GetString(0),
                        city = reader.GetString(1)
                    });
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return newList;
        }
        internal void AddNewUserLocation(int id, Location location)
        {
            string query = $"insert into [trainer_location] ([zipcode], [city], [trainerlocationid]) values (@zipcode, @city, @id)";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@zipcode", location.zipcode);
                sqlCommand.Parameters.AddWithValue("@city", location.city);
                sqlCommand.Parameters.AddWithValue("@id", id);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"updated...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal void UpdateNewUserLocation(int id, Location location) {
            string query = $"update [trainer_location] set [zipcode] = '{location.zipcode}', [city] = '{location.city}' where [trainerlocationid] = {id}";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@zipcode", location.zipcode);
                sqlCommand.Parameters.AddWithValue("@city", location.city);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"updated...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

       
        internal List<UpdateDetails> GetUpdateDetails(int id)
        {
            List<UpdateDetails> newList = new();
            string query = $"select [fullname], [phone], [website], [aboutme], [gender]  from [trainer_details] where [trainerid] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand newSqlCommand = new(query, conn);
                SqlDataReader reader = newSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    newList.Add(new UpdateDetails()
                    {
                        fullname = reader.GetString(3),
                        phone = reader.GetString(4),
                        website = reader.GetString(5),
                        aboutme = reader.GetString(6),
                        gender = reader.GetString(7),
                    });
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return newList;
        }
        internal void AddOtherDetails(int id, UpdateDetails details) {
            string query = $"update [trainer_details] set [fullname] = @fullname, [phone] = @phone, [website] = @website, [aboutme] = @aboutme, [gender] = @gender where [trainerid] = {id}";
            using SqlConnection conn = new(cs);
            try { 
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@fullname", details.fullname);
                sqlCommand.Parameters.AddWithValue("@phone", details.phone);
                sqlCommand.Parameters.AddWithValue("@website", details.website);
                sqlCommand.Parameters.AddWithValue("@aboutme", details.aboutme);
                sqlCommand.Parameters.AddWithValue("@gender", details.gender);
                try {
                    int rows = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"{rows}'s added");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal void DeleteUserData(int id) 
        {
            string query = $"delete from [trainer_details] where [trainerid] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand newSqlCommand = new(query, conn);
                int rows = newSqlCommand.ExecuteNonQuery();
                Console.WriteLine($"deleted {rows} from the table");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        
        

        internal int GetUserId (string email) {
            int id = 0;
            string query = $"select [trainerid] from [trainer_details] where [Email] = '{email}';";
            using SqlConnection con = new(cs);
            try
            {
                con.Open();
                SqlCommand cmd = new(query, con);
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return id;
        }
        internal void Adduser(Register user)
        {
            string query = "insert into [trainer_details] ([Email], [Password], [trainerid]) values (@email, @password, @trainerid);";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@email", user.email);
                sqlCommand.Parameters.AddWithValue("@password", user.password);
                sqlCommand.Parameters.AddWithValue("@trainerid", user.userid);
                try
                {
                    int rows = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"{rows} s added");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally { 
                conn.Close(); 
            }
            
        }
        internal bool CheckEmailExists(string email)
        {
            using SqlConnection con = new(cs);
            try
            {   
                con.Open();
                string query = "select [Email] from [trainer_details];";
                SqlCommand command = new(query, con);
                try
                {
                    List<string> list = new();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));
                    }
                    while (list.Count > 0)
                    {
                        if (list.Contains(email))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }


                //return false;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally { 
                con.Close(); 
            }
            return false;   
        }
        internal bool CheckUserExists(string email, string password)
        {
            using SqlConnection con = new(cs);
            try
            {
                con.Open();
                string query = "select [Email], [Password] from [trainer_details];";
                SqlCommand command = new(query, con);
                try
                {
                    Dictionary<string, string> dict = new();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if(!dict.ContainsKey(reader.GetString(0))) dict.Add(reader.GetString(0), reader.GetString(1));
                    }
                    while (dict.Count > 0) {
                        return dict.Any(entry => entry.Key == email && entry.Value == password);
                    }
                    
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return false;

        }
        
        // only for reference
        internal int CheckIdExists(string email) {
            int ID = 0;
            string query = $"select [trainerid] from testingado.userdetails where [Email] = '{email}';";
            using SqlConnection con = new(cs);
            try
            {
                con.Open();
                SqlCommand cmd = new(query, con);
                ID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally { 
                con.Close();
            }
            return ID;
        }
        internal bool CheckTrainerIdExists(string email, int id)
        {
            bool isExists = false;
            int ID;
            string query = $"select [trainerid] from [trainer_details] where [Email] = '{email}';";
            using SqlConnection con = new(cs);
            try
            {
                con.Open();
                SqlCommand cmd = new(query, con);
                ID = Convert.ToInt32(cmd.ExecuteScalar());
                if (ID == id)
                {
                    isExists = true;
                }
                else { 
                    isExists = false;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return isExists;
        }
        internal List<UserId> GetAllPersons() {
            List<UserId> newList = new();
            using SqlConnection con = new(cs);
            string query = "select [trainerid] from [trainer_details];";
            con.Open();
            SqlCommand command = new(query, con);
            //int userIdExists = Convert.ToInt32(command.ExecuteScalar());
            //if (userIdExists > 0) newList.Add(userIdExists);
            //string query = "select [Email], [Password] from testingado.signup;";
            //using SqlConnection con = new(cs);
            //try
            //{
            //    con.Open();
            //    SqlCommand command = new(query, con);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    newList.Add(new UserId(reader.GetInt32(0))
                    {
                        Id = reader.GetInt32(0),
                    });
                }
                return newList;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            return newList;
        } 
    }
}
 