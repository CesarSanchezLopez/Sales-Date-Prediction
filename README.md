# Sales-Date-Prediction

************Frontend Anular******************
### Instalación

1. **Clonar el repositorio**:

   git clone https://github.com/CesarSanchezLopez/Sales-Date-Prediction/
   
   cd tu_repositorio
   
2.  **Instalar las dependencias:**: 

   Una vez dentro del directorio del proyecto, instala las dependencias necesarias con npm:

   npm install

3.  **Ejecutar el Proyecto:**: 

   ng serve
   
4.  En Archivo \Frontend\Sales-Date-Prediction\src\environments\environment.ts
    Cambiar ruta donde se ejecutan las Apis: 
	
	export const environment = {
    production: false,
    api: 'https://localhost:7070/api',
  };
  
 5. Graficando con D3 
    \Sales-Date-Prediction\Frontend\d3
     
************Backend .Net 7******************

  
  **Base de Datos:**: 
    Ejecutar el scripts base de datos carpeta:  Sales-Date-Prediction\Backend\Sales-Date-Prediction\ScriptsDB:
	
     •  1.DBSetup.sql 
	 •  2.ScriptsDB.sql

  **Proyectos:**: 
    -SalesDatePrediction.Core
	-SalesDatePrediction.Infrastructure
    -SalesDatePrediction.Api 
	
  ** En Proyecto:SalesDatePrediction.Api**:
	•  Archivo appsettings.json cambiar cadena de conexion: 
	
	 "ConnectionStrings": {
     "DBConnectionString": "Server=.\\SQLEXPRESS;Database=StoreSample;Trusted_Connection=True;TrustServerCertificate=True"
     },

