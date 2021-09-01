using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DAL.Data.Migrations
{
    public partial class FillData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string listFullName = @"Пирожкова Тамара Елизаровна
Воробьева Майя Давидовна
Яблонцев Никон Евграфович
Лебедева Дина Серафимовна
Жданова Рада Николаевна
Трошкина Бронислава Тимофеевна
Квартовский Аристарх Архипович
Якушин Никифор Ефремович
Гребнев Емельян Пахомович
Кувардин Поликарп Самсонович
Ельцов Моисей Викентиевич
Кочкорбаева Жанна Леонидовна
Корниенко Лев Матвеевич
Черепанова Оксана Николаевна
Новикова Роза Марковна
Ключникова Тамара Германовна
Онегина Зоя Семеновна
Юхтриц Аскольд Валерьянович
Кетов Аким Матвеевич
Сутулина Лада Андрияновна
Оленева Стела Леонидовна
Саракаев Валентин Ипатович
Гребенникова Клара Алексеевна
Яценко Евграф Олегович
Лассмана Лариса Афанасиевна";

            string birhtday = @"04.02.2009
17.01.2008
12.12.2003
14.03.2008
30.10.2013
24.09.2008
03.12.2010
13.08.2018
15.05.2008
22.01.2020
28.12.2018
30.11.2009
11.12.2013
22.09.2008
17.11.2006
08.06.2012
20.04.2010
16.02.2017
12.03.2009
08.03.2004
07.12.2007
25.08.2010
24.06.2021
05.04.2010
16.12.2019";

            string titleBook = @"Baker Of The River
Criminal Of Rainbows
Turtles Of Wood
Giants Of Darkness
Snakes And Slaves
Descendants And Hunters
Confinement Without Courage
Moon Of The Stars
Vanish In My School
Symbols Of The Town
Clone Of The Fallen
Defender With Spaceships
Spies Of The Void
Emperors Of The Sun
Creatures And Traitors
Volunteers And Officers
Corruption Of The Void
Ascension Of Death
Bored By The Machines
Inspired By Robotic Control";

            string fullNameAuthor = @"Lewie Emery
Kirandeep Nixon
Loren Bate
Inez Leech
Nathaniel Salazar
Millicent Walker
Zeeshan Dodd
Mathilda Esquivel
Uwais Carter
Keeley Rawlings
Garrett Flowers
Johnny Hardy
Pollyanna Schroeder
Jasmine Alvarez
Yuvraj Costa
Aanya Hurst
Robin Peralta
Tanisha Wardle
Subhaan Stott
Braxton Thomas";


            var listFIO = listFullName.Split("\r\n");
            var listBirhtday = birhtday.Split("\r\n");
            var nameBook = titleBook.Split("\r\n");
            var authors = fullNameAuthor.Split("\r\n");

            migrationBuilder.InsertData(table: "Genries",
                columns: new string[] { "Id", "Name" },
                values: new object[] { 1, "horror" });

            migrationBuilder.InsertData(table: "Genries",
                columns: new string[] { "Id", "Name" },
                values: new object[] { 2, "Sci-Fi" });

            migrationBuilder.InsertData(table: "Genries",
                columns: new string[] { "Id", "Name" },
                values: new object[] { 3, "drama" });

            for (int i = 0; i < authors.Length; i++)
            {
                migrationBuilder.InsertData(table: "Authors",
                    columns: new string[] { "Id", "Name", "LastName" },
                    values: new object[] { i + 1, authors[i].Split(" ")[0], authors[i].Split(" ")[1] });

                migrationBuilder.InsertData(table: "Books",
                    columns: new string[] { "Id", "Title", "AuthorId" },
                    values: new object[] { i + 1, nameBook[i], i + 1 });
            }

            for (int i = 0; i < listBirhtday.Length; i++)
            {
                var fio = listFIO[i].Split(" ");
                migrationBuilder.InsertData(table: "Peoples",
                    columns: new string[] { "Id", "Name", "LastName", "MidleName", "Birthday" },
                    values: new object[] { i + 1, fio[0], fio[1], fio[2], DateTime.Parse(listBirhtday[i]) });
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
