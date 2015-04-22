using UnityEngine;
using System.Collections.Generic;

public class Element : MonoBehaviour
{

	private int id;
	private int neutron;
	private int electron;
	private string eName;
	private int pointValue;

	private Element (int id, int neutron, int electron, string eName, int pointValue)
	{
		this.id = id;
		this.neutron = neutron;
		this.electron = electron;
		this.eName = eName;
		this.pointValue = pointValue;
	}

	public static Element[] elements = new Element[] { new Element (0, 0, 0, "", 0), new Element (1, 1, 0, "Hydrogen", 100), 
		new Element (2, 2, 2, "Helium", 200), new Element (3, 4, 3, "Lithium", 300), 
		new Element (4, 5, 4, "Berylium", 400), new Element (5, 6, 5, "Boron", 500),
		new Element (6, 6, 6, "Carbon", 600), new Element (7, 7, 7, "Nitrogen", 700),
		new Element (8, 8, 8, "Oxygen", 800), new Element (9, 10, 9, "Flourine", 900),
		new Element (10, 10, 10, "Neon", 1000), new Element (11, 12, 11, "Sodium", 1100),
		new Element (12, 12, 12, "Magnesium", 1200), new Element (13, 14, 13, "Aluminum", 1300),
		new Element (14, 14, 14, "Silicon", 1400), new Element (15, 16, 15, "Phosphorus", 1500),
		new Element (16, 16, 16, "Sulfur", 1600), new Element (17, 18, 17, "Chlorine", 1700),
		new Element (18, 22, 18, "Argon", 1800), new Element (19, 20, 19, "Potassium", 1900),
		new Element (20, 20, 20, "Calcium", 2000), new Element (21, 24, 21, "Scandium", 2100),
		new Element (22, 26, 22, "Titanium", 2200), new Element (23, 28, 23, "Vanadium", 2300),
		new Element (24, 28, 24, "Chromium", 2400), new Element (25, 30, 25, "Manganese", 2500),
		new Element (26, 30, 26, "Iron", 2600), new Element (27, 32, 27, "Cobalt", 2700),
		new Element (28, 31, 28, "Nickel", 2800), new Element (29, 35, 29, "Copper", 2900),
		new Element (30, 35, 30, "Zinc", 3000), new Element (31, 39, 31, "Gallium", 3100),
		new Element (32, 41, 32, "Germanium", 3200), new Element (33, 42, 33, "Arsenic", 3300),
		new Element (34, 45, 34, "Selenium", 3400), new Element (35, 45, 35, "Bromine", 3500),
		new Element (36, 48, 36, "Krypton", 3600), new Element (37, 48, 37, "Rubidium", 3700),
		new Element (38, 50, 38, "Strontium", 3800), new Element (39, 50, 39, "Yttrium", 3900),
		new Element (40, 51, 40, "Zirconium", 3800), new Element (41, 52, 41, "Niobium", 4100),
		new Element (42, 54, 42, "Molybdenum", 4200), new Element (43, 55, 43, "Technetium", 4300),
		new Element (44, 57, 44, "Ruthenium", 4400), new Element (45, 58, 45, "Rhodium", 4500),
		new Element (46, 60, 46, "Palladium", 4600), new Element (47, 61, 47, "Silver", 4700),
		new Element (48, 64, 48, "Cadmium", 4800), new Element (49, 66, 49, "Indium", 4900),
		new Element (50, 69, 50, "Tin", 5000), new Element (51, 71, 51, "Antimony", 5100),
		new Element (52, 76, 52, "Tellurium", 5200), new Element (53, 74, 53, "Iodine", 5300),
		new Element (54, 77, 54, "Xenon", 5400), new Element (55, 78, 55, "Cesium", 5500),
		new Element (56, 81, 56, "Barium", 5600), new Element (57, 82, 57, "Lanthanum", 5700),
		new Element (58, 82, 58, "Cerium", 5800), new Element (59, 82, 59, "Praseodymium", 5900),
		new Element (60, 84, 60, "Neodymium", 6000), new Element (61, 84, 61, "Promethium", 6100),
		new Element (62, 88, 62, "Samarium", 6200), new Element (63, 89, 63, "Europium", 6300),
		new Element (64, 93, 64, "Gadolinium", 6400), new Element (65, 94, 65, "Terbium", 6500),
		new Element (66, 97, 66, "Dysprosium", 6600), new Element (67, 98, 67, "Holmium", 6700),
		new Element (68, 99, 68, "Erbium", 6800), new Element (69, 100, 69, "Thulium", 6900),
		new Element (70, 103, 70, "Ytterbium", 7000), new Element (71, 104, 71, "Lutetium", 7100),
		new Element (72, 106, 72, "Hafnium", 7200), new Element (73, 108, 73, "Tantalum", 7300),
		new Element (74, 110, 74, "Tungsten", 7400), new Element (75, 111, 75, "Rhenium", 7500),
		new Element (76, 114, 76, "Osmium", 7600), new Element (77, 115, 77, "Iridium", 7700),
		new Element (78, 117, 78, "Platinum", 7800), new Element (79, 118, 79, "Gold", 7900),
		new Element (80, 121, 80, "Mercury", 8000), new Element (81, 123, 81, "Thallium", 8100),
		new Element (82, 125, 82, "Lead", 8200), new Element (83, 126, 83, "Bismuth", 8300),
		new Element (84, 125, 84, "Polonium", 8400), new Element (85, 125, 85, "Astatine", 8500),
		new Element (86, 136, 86, "Radon", 8600), new Element (87, 136, 87, "Francium", 8700),
		new Element (88, 138, 88, "Radium", 8800), new Element (89, 138, 89, "Actinium", 8900),
		new Element (90, 142, 90, "Thorium", 9000), new Element (91, 140, 91, "Protactinium", 9100),
		new Element (92, 146, 92, "Uranium", 9200), new Element (93, 144, 93, "Neptunium", 9300),
		new Element (94, 150, 94, "Plutonium", 9400), new Element (95, 148, 95, "Americium", 9500),
		new Element (96, 151, 96, "Curium", 9600), new Element (97, 150, 97, "Berkelium", 9700),
		new Element (98, 153, 98, "Californium", 9800), new Element (99, 153, 99, "Einsteinium", 9900),
		new Element (100, 157, 100, "Fermium", 10000), new Element (101, 157, 101, "Mendelevium", 10100),
		new Element (102, 157, 102, "Nobelium", 10200), new Element (103, 159, 103, "Lawrencium", 10300),
		new Element (104, 157, 104, "Rutherfordium", 10400), new Element (105, 157, 105, "Dubnium", 10500),
		new Element (106, 157, 106, "Seaborgium", 10600), new Element (107, 155, 107, "Bohrium", 10700),
		new Element (108, 157, 108, "Hassium", 10800), new Element (109, 157, 109, "Meitnerium", 10900),
		new Element (110, 159, 110, "Darmstadtium", 11000), new Element (111, 161, 111, "Roentgenium", 11100),
		new Element (112, 165, 112, "Copernicium", 11200), new Element (113, 171, 113, "Ununtrium", 11300),
		new Element (114, 173, 114, "Flerovium", 11400), new Element (115, 170, 115, "Ununpentium", 11500),
		new Element (116, 177, 116, "Livermorium", 11600), new Element (117, 173, 117, "Ununseptium", 11700),
		new Element (118, 176, 118, "Ununoctium", 11800)

	};

	// Check to see what can currently be synthesized
	public static string getSynthesizableElement (int protonCount)
	{
		if (protonCount > 118) {
			return "Ununoctium";
		} else if (protonCount == 0) {
			return "Cannot Synthesize";
		} else {
			return elements[protonCount].eName;
		}
	}

	public static void synthesizeElement(int protonCount, int neutronCount, int electronCount)
	{
		int neutronDiff = neutronCount;
		int electronDiff = electronCount;
		int nScore = 0;
		int eScore = 0;
		int finalScore = 0;

		if (protonCount > 118) {
			protonCount = 118;

			if (neutronDiff < getNeutron(protonCount)) 
			{
				SharedValues_Script.neutrons -= neutronDiff;
			} else {
				SharedValues_Script.neutrons -= elements [118].neutron;
			}

			if (electronDiff < getElectron(protonCount))
			{
				SharedValues_Script.electrons -= electronDiff;
			} else {
				SharedValues_Script.electrons -= elements [118].electron;
			}

			nScore = neutronCount - getNeutron(protonCount);
			eScore = electronCount - getElectron(protonCount);

			Mathf.Abs(nScore);
			Mathf.Abs(eScore);

			finalScore = (nScore * 5) + (eScore * 5);

			SharedValues_Script.protons -= elements [118].id;
			SharedValues_Script.score += elements[118].pointValue - finalScore;
			SharedValues_Script.element = elements [118].eName;
			SharedValues_Script.elementTime = 100.0F;
		} else {
			if (neutronDiff < getNeutron(protonCount)) 
			{
				SharedValues_Script.neutrons -= neutronDiff;
			} else {
				SharedValues_Script.neutrons -= elements [protonCount].neutron;
			}
			
			if (electronDiff < getElectron(protonCount))
			{
				SharedValues_Script.electrons -= electronDiff;
			} else {
				SharedValues_Script.electrons -= elements [protonCount].electron;
			}

			nScore = neutronCount - getNeutron(protonCount);
			eScore = electronCount - getElectron(protonCount);
			
			Mathf.Abs(nScore);
			Mathf.Abs(eScore);
			
			finalScore = (nScore * 5) + (eScore * 5);

			SharedValues_Script.protons -= elements [protonCount].id;
			SharedValues_Script.score += elements [protonCount].pointValue - finalScore;
			SharedValues_Script.element = elements [protonCount].eName;
			SharedValues_Script.elementTime = 100.0F;
		}
	}

	// Get the id/protons associated with the element
	public static int getId (int protonCount)
	{
		return elements[protonCount].id;
	}

	// Get the defualt neutrons associated with the element
	public static int getNeutron (int protonCount)
	{
		return elements[protonCount].neutron;
	}

	// Get the defualt electrons associated with the element
	public static int getElectron (int protonCount)
	{
		return elements[protonCount].electron;
	}

	// Get the name associated with the element
	public static string getEName (int protonCount)
	{
		return elements[protonCount].eName;
	}

	// Get the point value associated with the element
	public static int getPointValue (int protonCount)
	{
		return elements[protonCount].pointValue;
	}

}
