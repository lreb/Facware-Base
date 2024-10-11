from flask import Flask, jsonify
from flask_restful import Api, Resource
from flask_swagger_ui import get_swaggerui_blueprint

app = Flask(__name__)
api = Api(app)

# Define a simple resource
class HelloWorld(Resource):
    def get(self):
        return {'hello': 'world'}

api.add_resource(HelloWorld, '/')

# Swagger configuration
SWAGGER_URL = '/swagger'
API_URL = '/static/swagger.json'
swaggerui_blueprint = get_swaggerui_blueprint(
    SWAGGER_URL,
    API_URL,
    config={
        'app_name': "Flask API with Swagger"
    }
)
app.register_blueprint(swaggerui_blueprint, url_prefix=SWAGGER_URL)

# Serve the Swagger JSON
@app.route('/static/swagger.json')
def swagger_json():
    return jsonify({
        "swagger": "2.0",
        "info": {
            "title": "Flask API",
            "description": "API documentation",
            "version": "1.0.0"
        },
        "basePath": "/",
        "paths": {
            "/": {
                "get": {
                    "summary": "Hello World",
                    "description": "Returns a hello world message",
                    "responses": {
                        "200": {
                            "description": "A hello world message",
                            "schema": {
                                "type": "object",
                                "properties": {
                                    "hello": {
                                        "type": "string"
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    })

if __name__ == '__main__':
    app.run(debug=True)