# PowerPlan

PowerPlan is an open-source software tool for probabilistic planning of reconductoring in electricity distribution networks. The software integrates probabilistic load modeling, Monte Carlo scenario generation, exhaustive search optimization, and power flow simulation using OpenDSS.

---

## ✨ Features

* Probabilistic modeling of load growth using probability density functions
* Monte Carlo scenario generation
* Exhaustive search optimization of reconductoring alternatives
* Integration with OpenDSS for power flow simulation
* Internal graphical visualization of results
* Export of advanced plots via MATLAB (.m files)
* Database management of conductors and network parameters

---

## 🧠 Methodological Background

PowerPlan implements a probabilistic multi-stage optimization methodology for reconductoring planning under load uncertainty, as described in the associated research publication.

---

## 🖥️ Requirements

* Windows OS
* .NET Framework
* OpenDSS installed
* SQL Server Compact (SQL Server CE)

---

## ⚙️ Installation

1. Clone the repository:

```bash
git clone https://github.com/YOUR_REPOSITORY/PowerPlan.git
```

2. Open the solution in Visual Studio

3. Build the project using .NET Framework

4. Ensure OpenDSS and SQL Server Compact are properly installed

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
