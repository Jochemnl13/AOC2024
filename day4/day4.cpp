#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <algorithm>

bool checkWord(const std::vector<std::string>& grid, int row, int col) {
    if (row + 2 < grid.size() && col + 2 < grid[0].size()) {
        if ((grid[row][col] == 'M' && grid[row + 1][col + 1] == 'A' && grid[row + 2][col + 2] == 'S') || (grid[row][col] == 'S' && grid[row + 1][col + 1] == 'A' && grid[row + 2][col + 2] == 'M'))  {
            if ((grid[row + 2][col] == 'M' && grid[row + 1][col + 1] == 'A' && grid[row][col + 2] == 'S') || (grid[row + 2][col] == 'S' && grid[row + 1][col + 1] == 'A' && grid[row][col + 2] == 'M')) {
                return true;
            }
        }
    }

    return false;
}

int main() {
    std::string filename = "input.txt";
    std::ifstream file(filename);
    std::vector<std::string> grid;
    std::string line;

    while (std::getline(file, line)) {
        grid.push_back(line);
    }

    int totalSum = 0;
    int rows = grid.size();
    int cols = grid[0].size();

    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            if (checkWord(grid, i, j)) {
                totalSum++;
            }
        }
    }

    std::cout << "Total sum: " << totalSum << std::endl;

    return 0;
}