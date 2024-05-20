import json

# Define the responses for each entry
responses = {
    "weather": "Today's weather is sunny with a high of 75 degrees Fahrenheit.",
    "what is your name": "I am Bard, a large language model.",
    "tell me a joke": "Why did the scarecrow win an award? Because he was outstanding in his field!",
    "go away": "See you later!"
}

# Create a dictionary to hold the entries
data = {}

# Populate the dictionary with entries from 65 to 89
for i in range(65, 90):
    if i % 2 == 1:  # Odd numbers get the first set of responses
        data[str(i)] = {
            "weather": responses["weather"],
            "what is your name": responses["what is your name"]
        }
    else:  # Even numbers get the second set of responses
        data[str(i)] = {
            "tell me a joke": responses["tell me a joke"],
            "go away": responses["go away"]
        }

# Convert the dictionary to a JSON string with pretty printing
json_output = json.dumps(data, indent=4)

# Write the JSON output to a file
with open('output.json', 'w') as json_file:
    json_file.write(json_output)

print("JSON output has been written to output.json")
