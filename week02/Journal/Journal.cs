using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Journal
{
    private const string Separator = "~|~";
    private const string CsvHeader = "Date,Prompt,Response";
    private List<Entry> _entries = new();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using StreamWriter writer = new(filename);
        writer.WriteLine(CsvHeader);
        foreach (Entry entry in _entries)
        {
            writer.WriteLine($"{EscapeCsvField(entry.Date)},{EscapeCsvField(entry.Prompt)},{EscapeCsvField(entry.Response)}");
        }
    }

    public void LoadFromFile(string filename)
    {
        List<Entry> loadedEntries = new();

        using StreamReader reader = new(filename);
        string firstLine = reader.ReadLine();
        if (firstLine == null)
        {
            _entries = loadedEntries;
            return;
        }

        if (firstLine.Equals(CsvHeader, StringComparison.OrdinalIgnoreCase))
        {
            List<string> record;
            while ((record = ReadCsvRecord(reader)) != null)
            {
                if (record.Count != 3)
                {
                    throw new FormatException("Journal CSV entries must contain exactly three fields.");
                }

                loadedEntries.Add(new Entry(record[0], record[1], record[2]));
            }

            _entries = loadedEntries;
            return;
        }

        // Continue to accept journals saved in the original separator-delimited format.
        AddLegacyEntry(firstLine, loadedEntries);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            AddLegacyEntry(line, loadedEntries);
        }

        _entries = loadedEntries;
    }

    private static string EscapeCsvField(string field)
    {
        if (!field.Contains(',') && !field.Contains('"') && !field.Contains('\r') && !field.Contains('\n'))
        {
            return field;
        }

        return $"\"{field.Replace("\"", "\"\"")}\"";
    }

    private static List<string> ReadCsvRecord(TextReader reader)
    {
        List<string> fields = new();
        StringBuilder field = new();
        bool inQuotes = false;
        bool quoteClosed = false;
        bool hasContent = false;

        while (true)
        {
            int next = reader.Read();
            if (next == -1)
            {
                if (inQuotes)
                {
                    throw new FormatException("Journal CSV contains an unterminated quoted field.");
                }

                if (!hasContent && fields.Count == 0 && field.Length == 0)
                {
                    return null;
                }

                fields.Add(field.ToString());
                return fields;
            }

            char character = (char)next;
            hasContent = true;

            if (inQuotes)
            {
                if (character != '"')
                {
                    field.Append(character);
                }
                else if (reader.Peek() == '"')
                {
                    reader.Read();
                    field.Append('"');
                }
                else
                {
                    inQuotes = false;
                    quoteClosed = true;
                }

                continue;
            }

            if (character == ',')
            {
                fields.Add(field.ToString());
                field.Clear();
                quoteClosed = false;
                hasContent = false;
            }
            else if (character == '\r' || character == '\n')
            {
                if (character == '\r' && reader.Peek() == '\n')
                {
                    reader.Read();
                }

                fields.Add(field.ToString());
                return fields;
            }
            else if (character == '"' && field.Length == 0 && !quoteClosed)
            {
                inQuotes = true;
            }
            else if (quoteClosed)
            {
                throw new FormatException("Journal CSV contains unexpected text after a quoted field.");
            }
            else
            {
                field.Append(character);
            }
        }
    }

    private static void AddLegacyEntry(string line, List<Entry> entries)
    {
        string[] parts = line.Split(new[] { Separator }, 3, StringSplitOptions.None);
        if (parts.Length != 3)
        {
            throw new FormatException($"Invalid journal entry in file: {line}");
        }

        entries.Add(new Entry(parts[0], parts[1], parts[2]));
    }
}