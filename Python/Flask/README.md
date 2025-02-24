Step 1: Create the virtual environment
```bash
python3 -m venv .venv
```

Step 2: Activate the virtual environment
```bash
source .venv/bin/activate
```

Step 3: Install all the required dependencies
```bash
pip install <dependencies name>
```

Step 4: Run the freeze command
```bash
pip freeze > requirements.txt
```

Run application
```bash
 python main.py 
```


Open web browser with this URL with swagger definition
`http://localhost:5000/swagger`
without swagger definition 
`http://localhost:5000`