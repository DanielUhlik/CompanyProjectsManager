# Použité technológie

  - backend - Asp.Net core
  - frontend - vue.js, bootstrap

# Oddôvodnenie technoológii

### Asp.Net core
- nezávislosť na použitom zariadení / OS
- rýchlosť

### Vue.js
- rýchlosť
- jednoduchosť

# Popis
Aplikácia je vytvorená v trojvrstvovej architektúre s oddelením dátovej, aplikačnej a prezentačnej vrstvy.
V prípade potreby úpravy aplikačnej alebo dátovej vrstvy sa použije existujúci interface vrstvy v Services/DAL/Interfaces/IProjectsDAL.cs alebo Services/Logic/Interfaces/IProjectsService.cs a nový service/DAL sa pridá do DI v Startup.cs.

            services.AddSingleton<IProjectsDAL, ProjectsXmlDAL>();
            services.AddTransient<IProjectsService, ProjectsService>();

Client je vytvorený ako vue.js SPA aplikácia

# Použité knižnice tretích strán na backende
- Serilog.Extensions.Logging.File
