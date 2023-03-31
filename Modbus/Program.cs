byte[] tab = { 0x01,0x05,0x20,0x02,0x70,0x00 };

string[] tab2 = new string [6];


Console.WriteLine();

static string CalculateCRC(byte[] data)
{
    ushort crc = 0xFFFF;

    for (int i = 0; i < data.Length; i++)
    {
        crc ^= data[i];

        for (int j = 0; j < 8; j++)
        {
            if ((crc & 0x0001) == 0x0001)
            {
                crc >>= 1;
                crc ^= 0xA001;
            }
            else
            {
                crc >>= 1;
            }
        }
    }

    return crc.ToString("X");
}

string napis;
int number;

Console.WriteLine("Podaj adres urządzenia z zakresu 1-255");
napis = Console.ReadLine();

number = int.Parse(napis);

string hex = number.ToString("X");

tab2[0] = hex;

Console.WriteLine("Podaj adres szyny z zakresu 1-8");
napis = Console.ReadLine();

number = int.Parse(napis);

hex = number.ToString("X");

tab2[1] = hex;


tab2[2] = "20";

tab2[3] = "02";


Console.WriteLine("Podaj procentową moc falownika");
napis = Console.ReadLine();


tab2[4] = napis;

tab2[5] = "00";




byte[] tab3 = new byte[6];

int index = 0;

foreach (string liczba in tab2)
{
    if (byte.TryParse(liczba, out byte wynik))
    {
        tab3[index] = wynik;
        index++;
    }
}

Console.WriteLine(tab3[0] + " " + tab3[1] + " " + tab3[2] + " " + tab3[3] + " " + tab3[4] + " " + tab3[5] + " ");

Console.WriteLine(CalculateCRC(tab3));





