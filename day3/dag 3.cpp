#include <iostream>
#include <fstream>
#include <regex>
#include <string>

int main()
{
    std::string filename = "input.txt";
    std::ifstream file(filename);
    std::regex pattern(R"(mul\(([0-9]{1,3}),([0-9]{1,3})\)|do\(\)|don['’]t\(\))");
    std::smatch match;
    std::string line;
    int totalSum = 0;
    int enabled = true;

    while (std::getline(file, line)) {
        std::sregex_iterator begin(line.begin(), line.end(), pattern);
        std::sregex_iterator end;
        
        for (std::sregex_iterator it = begin; it != end; ++it) {
            match = *it;

            if (match[0].str() == "don't()") {
                enabled = false;
                continue;
            }
            else if (match[0].str() == "do()") {
                enabled = true;
                continue;
            }
            if (enabled) {
                totalSum += std::stoi(match[1].str()) * std::stoi(match[2].str());
            }
        }
    }

    file.close();

    std::cout << "Total sum: " << totalSum << std::endl;

    return 0;
}
