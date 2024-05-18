import json
import os

# Define the base directory and base filename
base_dir = r'C:\SAD2\Part4'
base_filename = 'ParserInput'

# Create the directory if it doesn't exist
if not os.path.exists(base_dir):
    os.makedirs(base_dir)

# Define the sample data to be written to each JSON file
sample_data = {
  "help": "Help INFO...",
  "computer lab": "I heard that it was free tonight... Maybe you should ask LARRY about it. He's dying to get in.",
  "goodbye": "See ya!"
}


# Start number for the filenames
start_number = 65

# Loop to create 25 JSON files
for i in range(25):
    # Define the filename
    filename = os.path.join(base_dir, f"{base_filename}{start_number + i}.json")
    
    # Write the sample data to the JSON file
    with open(filename, 'w') as json_file:
        json.dump(sample_data, json_file, indent=4)

print("25 JSON files have been created successfully.")
