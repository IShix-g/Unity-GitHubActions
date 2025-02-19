import sys
import json
import re

# 引数を取得
if len(sys.argv) != 3:
    print("Usage: python3 convert_to_sarif.py <input_log> <output_sarif>")
    sys.exit(1)

input_log_path = sys.argv[1]     # 解析するStyleCopログファイルのパス
output_sarif_path = sys.argv[2]  # 出力するSARIFファイルのパス

# SARIF フォーマットの初期構造
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

# エラー/警告を解析する正規表現
log_pattern = re.compile(
    r"(?P<file>.+)\((?P<line>\d+),(?P<column>\d+)\): (?P<level>\w+) (?P<rule>\w+): (?P<message>.+)"
)

# ログを走査して結果を抽出
with open(input_log_path, "r") as log_file:
    for line in log_file:
        match = log_pattern.search(line)
        if match:
            file_path = match.group("file")
            line_number = int(match.group("line"))
            column_number = int(match.group("column"))
            level = match.group("level").lower()  # "error", "warning" を小文字化
            rule_id = match.group("rule")
            message = match.group("message")

            # SARIF の result オブジェクト
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

            # 結果を SARIF の results に追加
            sarif_data["runs"][0]["results"].append(sarif_result)

# SARIF データをファイルに書き込む
with open(output_sarif_path, "w") as sarif_file:
    json.dump(sarif_data, sarif_file, indent=2)

print(f"SARIF file generated: {output_sarif_path}")