clear; 
 clc; 
 DadosHistograma=[
330646.4152, 
363935.6502, 
363935.6502, 
370873.9345, 
331735.2827, 
365024.5177, 
365024.5177, 
371962.802, 
342028.5311, 
375317.7661, 
375317.7661, 
382256.0504, 
358808.2283, 
392097.4633, 
392097.4633, 
399035.7476, 
330646.4152, 
363935.6502, 
363935.6502, 
370873.9345, 
340667.4467, 
373956.6817, 
373956.6817, 
380894.966, 
345601.3967, 
378890.6317, 
378890.6317, 
385828.916, 
358808.2283, 
392097.4633, 
392097.4633, 
399035.7476, 
331735.2827, 
365024.5177, 
365024.5177, 
371962.802, 
342028.5311, 
375317.7661, 
375317.7661, 
382256.0504, 
345601.3967, 
378890.6317, 
378890.6317, 
385828.916, 
358808.2283, 
392097.4633, 
392097.4633, 
399035.7476, 
342028.5311, 
375317.7661, 
375317.7661, 
382256.0504, 
345601.3967, 
378890.6317, 
378890.6317, 
385828.916, 
358808.2283, 
392097.4633, 
392097.4633, 
399035.7476, 
358808.2283, 
392097.4633, 
392097.4633, 
399035.7476, 
]; 
 [Y, X] = hist(DadosHistograma, 5); Y = Y / sum(Y) * 100; figure('Color',[1 1 1]); hold on; grid on; bar(X, Y, 1);  
xlabel('Investment value (in USD)'); 
 ylabel('Probability of occurrence (%)'); 
set(gca, 'Xcolor',[0.3 0.3 0.3]); 
 set(gca, 'Ycolor',[0.3 0.3 0.3]);
screenSize = get(0, 'ScreenSize'); 
 width = 880; 
 height = 660; 
  x = (screenSize(3) - width) / 2; 
  y = (screenSize(4) - height) / 2; 
 set(gca,'FontSize', 12); 
 set(gcf, 'Position', [x, y, width, height]); 
 xtickformat('%,.1f'); ytickformat('%,.1f');
LimiteSuperiorX = (floor(max(X)) + 10000); 
 LimiteInferiorX = (floor(min(X)) - 10000); 
 if (LimiteInferiorX == LimiteSuperiorX) 
 LimiteSuperiorX = LimiteSuperiorX + 10000; 
 LimiteInferiorX = LimiteInferiorX - 10000; 
 end
LimiteSuperiorY = (floor(max(Y)) + 1); 
 axis([LimiteInferiorX, LimiteSuperiorX, 0, LimiteSuperiorY]);
ValorLimiteINFERIORIntervaloConfianca = prctile(DadosHistograma, (100 - 95) / 2); 
 plot([ValorLimiteINFERIORIntervaloConfianca ValorLimiteINFERIORIntervaloConfianca], [0 LimiteSuperiorY], 'Color', 'r', 'LineWidth', 2);
ValorLimiteSUPERIORIntervaloConfianca = prctile(DadosHistograma, 100 - (100 - 95) / 2); 
 plot([ValorLimiteSUPERIORIntervaloConfianca ValorLimiteSUPERIORIntervaloConfianca], [0 LimiteSuperiorY], 'Color', 'r', 'LineWidth', 2);
