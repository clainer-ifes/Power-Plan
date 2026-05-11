# PowerPlan

Power Plan is an open-source software tool for probabilistic planning of reconductoring investments in electricity distribution networks. The software integrates probabilistic load modeling, Monte Carlo scenario generation, exhaustive search optimization, and power flow simulation using OpenDSS®.

The tool was developed in C# using the .NET Framework and provides an interactive graphical environment for configuring probabilistic planning studies under load uncertainty conditions.

---	

## ✨ Main Features

* Probabilistic modeling of load growth using probability density functions
* Monte Carlo generation of demand scenarios
* Exhaustive search optimization of reconductoring alternatives
* Automatic integration with OpenDSS® for power flow simulation
* Verification of operational constraints such as conductor loading and voltage limits
* Internal graphical visualization of probabilistic planning results
* Export of MATLAB (.m) scripts for advanced customized visualization
* Database management of conductor technical and economic parameters

---

## 🧠 Methodological Background

Power Plan implements a probabilistic multi-stage optimization methodology for reconductoring planning under load uncertainty conditions, as presented in the associated scientific publication.

The software is specifically focused on probabilistic reconductoring planning and is not intended to replace comprehensive active distribution planning frameworks.

---

## 🖥️ Requirements

Recommended environment:

* Windows 10 or newer
* Visual Studio 2022 (or compatible)
* .NET Framework 4.8
* OpenDSS® installed locally
* SQL Server Compact 4.0 (SQL Server CE)

Optional:

* MATLAB® (only required for executing exported .m visualization scripts)

---

## ⚙️ Installation

1. Clone the repository
git clone https://github.com/clainer-ifes/Power-Plan.git

2. Open the project

Open the solution file (PowerPlan.sln) using Visual Studio.

3. Build the solution

Compile the project using the Release or Debug configuration.

4. Install OpenDSS®

Power Plan communicates with OpenDSS®. OpenDSS® must be installed locally before executing the software.

5. Install SQL Server Compact

Ensure SQL Server Compact 4.0 is installed on the system before execution.
---

## 🚀 Usage

1. Load or define network data
2. Configure probabilistic parameters (PDF, growth rates)
3. Select candidate conductors and constraints
4. Run the optimization
5. Analyze results using:

   * Built-in graphical outputs
   * Exported MATLAB scripts for advanced visualization
---

## 📊 Outputs

PowerPlan provides two types of outputs:

### Built-in visualization

* Investment histograms
* Scenario-based results

### Advanced visualization (external)

* MATLAB (.m) scripts for customized plots
* Network graphs highlighting reinforced segments

---

## ⚠️ Troubleshooting

OpenDSS® connection issues
* Verify that OpenDSS® is correctly installed
* Ensure the COM interface is available
* Restart Visual Studio after installing OpenDSS®

Database-related issues
* Verify that SQL Server Compact 4.0 is installed

Execution issues
* Run Visual Studio with administrator privileges if necessary
* Verify compatibility with .NET Framework 4.8

---

## 🎓 Educational Use

PowerPlan is particularly suitable for academic purposes, including undergraduate and graduate courses related to:

* Power system planning
* Optimization methods
* Computational intelligence in engineering

---

## ⚡ Industrial Application

The software can also be used by electricity distribution utilities as a decision-support tool for evaluating reconductoring strategies under uncertainty.

---

## ⚠️ Note on Commercial Use

This software is released under the MIT License, which permits commercial use.

However, the author encourages its use primarily for academic, research, and educational purposes, as well as for non-commercial technical studies.

Organizations interested in commercial applications or large-scale deployment are encouraged to contact the authors for collaboration or further discussion.

---

## 📜 License

This project is licensed under the MIT License.

---

## 📧 Contact

Clainer Bravin Donadel
Federal Institute of Espírito Santo (IFES)
Email: cdonadel@ifes.edu.br

