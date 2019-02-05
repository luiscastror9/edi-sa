restore filelistonly
from Disk = 'D:\CNV\CNV-Intranet\CNV.bak'


REstore DATABASE CNV
from Disk = 'D:\CNV\CNV-Intranet\CNV.bak'
with move 'CNV' to 'D:\CNV\CNV-INTRANET\CNV-OLD INTRANET\APP_DATA\CNV.MDF',
 move 'CNV_log' to 'D:\CNV\CNV-INTRANET\CNV-OLD INTRANET\APP_DATA\CNV.ldf',
replace;