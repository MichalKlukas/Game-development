import csv

def calculate_average(csv_file):
    # Initialize variables to calculate the sum and count of valid numbers
    total = 0
    count = 0

    # Open the CSV file for reading
    with open(csv_file, mode='r') as file:
        reader = csv.reader(file, delimiter=';')  # Specify semicolon as the delimiter

        # Skip the header (first line)
        next(reader)

        # Iterate through each row in the CSV file
        for row in reader:
            # Ensure the row has at least 3 columns
            if len(row) >= 3:
                try:
                    # Access the third column (index 2 in zero-based indexing) and trim any extra spaces
                    value = float(row[2].strip())  # Convert to float after trimming whitespace
                    total += value
                    count += 1
                except ValueError:
                    # Skip rows where the third column is not a valid number
                    continue

    # Calculate and return the average
    if count > 0:
        average = total / count
        return average
    else:
        return None

# Specify the path to your CSV file
csv_file = 'frameTime30.csv'

# Get the average of the third column
average = calculate_average(csv_file)

if average is not None:
    # Round the average to 4 decimal places and replace the dot with a comma for the formatted output
    formatted_average = f"{average:.8f}".replace('.', ',')
    print(f"The average of the third column is: {formatted_average}")
else:
    print("No valid numeric values found in the third column.")
