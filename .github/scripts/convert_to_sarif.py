import sys
import json
import re

if len(sys.argv) != 3:
    print("Usage: python3 convert_to_sarif.py <input_log> <output_sarif>")
    sys.exit(1)

input_log_path = sys.argv[1]
output_sarif_path = sys.argv[2]

sarif_data = {
    "version": "2.1.0",
    "runs": [
        {
            "tool": {
                "driver": {
                    "name": "StyleCop",
                    "version": "1.0",
                    "informationUri": "https://github.com/StyleCop",
                    "rules": []
                }
            },
            "results": []
        }
    ]
}

log_pattern = re.compile(
    r"(?P<file>.+)\((?P<line>\d+),(?P<column>\d+)\): (?P<level>\w+) (?P<rule>\w+): (?P<message>.+)"
)

with open(input_log_path, "r") as log_file:
    for line in log_file:
        match = log_pattern.search(line)
        if match:
            file_path = match.group("file")
            line_number = int(match.group("line"))
            column_number = int(match.group("column"))
            level = match.group("level").lower()
            rule_id = match.group("rule")
            
            original_message = match.group("message")
            message = re.sub(r"\s*\[.+?\]\s*$", "", original_message)

            sarif_result = {
                "ruleId": rule_id,
                "level": level,
                "message": {"text": message},
                "locations": [
                    {
                        "physicalLocation": {
                            "artifactLocation": {"uri": file_path},
                            "region": {
                                "startLine": line_number,
                                "startColumn": column_number
                            }
                        }
                    }
                ]
            }

            sarif_data["runs"][0]["results"].append(sarif_result)

with open(output_sarif_path, "w") as sarif_file:
    json.dump(sarif_data, sarif_file, indent=2)

print(f"SARIF file generated: {output_sarif_path}")