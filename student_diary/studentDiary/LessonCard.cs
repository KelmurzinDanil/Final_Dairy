﻿using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace studentDiary
{
    public partial class LessonCardWindow : Form
    {
        public string Lesson { get; set; }
        public LessonCardWindow(string lesson, int numberWeek)
        {
            MaximizeBox = false;
            InitializeComponent();
            Lesson = lesson;
            FillTextCard(lesson, numberWeek);
        }
        public void FillTextCard(string lesson, int numberWeek)
        {

            DB dB = new DB();
            dB.OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `lesson` WHERE `LessonName` = @lN", dB.GetConnection());
            mySqlCommand.Parameters.Add("@lN", MySqlDbType.VarChar).Value = lesson;
            DateTime dateTime = DateTime.Now;
            int dayDateTime = (int)DateTime.Now.DayOfWeek;
            using (MySqlDataReader oReader = mySqlCommand.ExecuteReader())
            {
                if (oReader.Read())
                {
                    NameCardLesson.Text = oReader.GetString("LessonName");
                    ProfessorNameCardLesson.Text = oReader.GetString("LessonProfessor");
                    DataNameCardLesson.Text = dateTime.AddDays(dayDateTime + (7 - numberWeek)).ToString();
                    var ordinal = oReader.GetOrdinal("LessonNote");
                    if (!oReader.IsDBNull(ordinal))
                        NoteCardLesson.Text = oReader.GetString("LessonNote");
                }
            }
            dB.CloseConnection();
        }

        private void SaveCardLessonBtn_Click(object sender, EventArgs e)
        {
            DB dB = new DB();
            MySqlCommand mySqlCommand2 = new MySqlCommand("UPDATE `lesson` SET `LessonNote` = @lesN WHERE `LessonName` = @lN", dB.GetConnection());
            mySqlCommand2.Parameters.Add("@lN", MySqlDbType.VarChar).Value = Lesson;
            dB.OpenConnection();
            if (NoteCardLesson.Text != String.Empty)
            {
                mySqlCommand2.Parameters.Add("@lesN", MySqlDbType.VarChar).Value = NoteCardLesson.Text;
                if (mySqlCommand2.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Создан"); ;
                }
                else
                {
                    MessageBox.Show("Не создан");
                }
            }
            dB.CloseConnection();
        }
    }
}
