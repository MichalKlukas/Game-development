import pandas as pd
import matplotlib.pyplot as plt

# Data from the table
data = {
    'NPC': [1, 200, 400, 600, 800, 1000],
    'Slow / 0.3': [452.8559519, 214.2680609, 144.7316105, 93.56300425, 73.82931704, 37.96236092],
    'Slow / 0.45': [406.6661529, 201.7464118, 120.8674373, 86.82116151, 49.7129947, 35.64615852],
    'Slow / 0.6': [390.3869174, 205.7464108, 122.9296126, 74.4463904, 37.11268306, 27.79746266],
    'Fast / 0.3': [340.2803958, 182.8037784, 107.8516869, 84.25640437, 42.74840737, 35.48219667],
    'Fast / 0.45': [339.7490294, 168.9682522, 107.0927811, 76.94367001, 35.64927881, 27.12424376],
    'Fast / 0.6': [292.3158423, 139.2647441, 88.16727229, 59.2932066, 34.90350258, 24.44466856]
}

# Create a DataFrame
df = pd.DataFrame(data)

# Plotting the data
plt.figure(figsize=(10, 6))
for column in df.columns[1:]:  # Skip the 'NPC' column
    plt.plot(df['NPC'], df[column], label=column)

# Set logarithmic scale for Y-axis
plt.yscale('log')

# Set custom Y-axis ticks without 10, 5, and 1, focusing on higher values like 25, 50, etc.
plt.yticks([400, 200, 100, 50, 25, 20], 
           ['400', '200', '100', '50', '25', '20'])

# Adding labels and title
plt.xlabel('Number of NPCs')
plt.ylabel('FPS')
plt.title('FPS drops with different settings')
plt.legend()
plt.grid(True)
plt.show()
