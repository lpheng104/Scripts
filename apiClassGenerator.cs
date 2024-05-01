using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class apiClassGenerator : MonoBehaviour
{
    private string readAPIdata()
    {
        string filePath = "Assets/Data Files/api_input.txt"; // Path to the file
        string answer = "";

        // Check if the file exists
        if (File.Exists(filePath))
        {
            try
            {
                // Open the file to read from
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    // Read and display lines from the file until the end of the file is reached
                    while ((line = reader.ReadLine()) != null)
                    {
                        answer = answer + line;
                    }
                    return answer;
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occurred during reading the file
                print("An error occurred while reading the file:");
                print(ex.Message);
                return null;
            }
        }
        else
        {
            print("The file does not exist.");
            return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        String fileText = this.readAPIdata();
        string[] parts = fileText.Split(",");
        string answer = "using UnityEngine;\n\n[System.Serializable]\npublic class [ClassName]\n{\n";
        string constructorParams = "";
        string constructorBody = "";
        foreach (string s in parts)
        {

            string[] pair = s.Split(":");
            string varName = pair[0].Trim().Substring(1, pair[0].Length - 2);

            //what kind of value is it
            if (pair[1].Trim()[0] == '"')
            {
                answer += "\tpublic string " + varName + ";\n";
                constructorParams += "string " + varName + ",";
            }
            else if (pair[1][0] == '{')
            {
                answer += "\tpublic [Another Object Type] " + varName + ";\n";
                constructorParams += "[Another Object Type] " + varName + ",";
            }
            else
            {
                answer += "\tpublic int " + varName + ";\n";
                constructorParams += "int " + varName + ",";
            }

            constructorBody += "\n\t\tthis." + varName + " = " + varName + ";";
        }
        answer += "\n\tpublic [ClassName](" + constructorParams.Substring(0, constructorParams.Length - 1) + ")\n";
        answer += "\t{" + constructorBody + "\n\t}\n}";
        print(answer);

    }

    // Update is called once per frame
    void Update()
    {

    }
}