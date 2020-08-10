import numpy as np

with open("./result/no_vibration/test.txt") as f:
    l = f.readlines()

l.pop(0)

y = []
for data in l:
    data = data.split(" ")
    y.append(float(data[2]))

print(np.mean(y))
