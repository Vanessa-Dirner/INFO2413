



############# queries
$seedQuantityCheck = "use project;SELECT batch FROM inventory WHERE quantity < 500;"
$expiringSeedscheck = "use project;SELECT batch FROM inventory WHERE expirationdate >= dateadd(year, +1, getdate());"
$wastedSeedsCheck = "use project;SELECT batch FROM inventory WHERE expirationdate < getdate();"

##### shared email info

$subject = "Vegetable Seed Managment System"
$body = "Dear Systems Administrator, please see the following report.   Sent via Systems Managment System"
$to = "samplefarmseedsco@gmail.com" 
$from = "samplefarmseedsco@gmail.com"   
$SmtpServer = 'smtp.gmail.com' 
$Port = 587 

########################################################################################################################################################################
Write-Output "FIRST QUERY"

$querytimeout = 120
$conn = New-Object System.Data.SqlClient.SqlConnection
$ConnectionString = "Data Source=desktop-ub0lhnh;Initial Catalog=project;Integrated Security=True;"
$conn.ConnectionSTring = $ConnectionString
$conn.Open()

$cmd = New-Object System.Data.SqlClient.SqlCommand($seedQuantityCheck, $conn)
$cmd.CommandTimeout=$querytimeout


##execute query, read result
$ds = New-Object System.Data.DataSet
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
[void]$da.fill($ds)

$result1 = $ds

$tables = $result1.tables 


if ($result1 = "") {
    Write-Output "There's no seeds with quantity under 500"
} else {
    $Body = "Dear Systems Administrator, please see the following report of seeds with quantities under 500g." + $result1 + "Sent via Systems Managment System"
    clear-content .\LowInventoryBatches.csv
    foreach ($table in $tables) {
       $table | out-file LowInventoryBatches.csv
       $table
    }
    $path = "C:\Users\Vanessa\Desktop\GitHub\INFO2413\LowInventoryBatches.csv"
    $path
    $smtpmessage = new-object System.Net.Mail.MailMessage($from,$to,$subject,$body)
    $attachment = New-Object System.Net.Mail.Attachment($path)
    $SMTPMessage.Attachments.Add($attachment)
     $SMTPClient = new-object Net.Mail.SMTPClient($smtpserver, $port)
     $SMTPClient.enablessl = $true
     $SMTPClient.Credentials = New-Object System.Net.NetworkCredential("samplefarmseedsco@gmail.com", "nqlgvacxneplndbt"); 
     $smtpclient.send($smtpmessage)
}
## clear things for next query
$conn.close()
$ds = ""
$da = ""

########################################################################################################################
Write-Output "SECOND QUERY"

$conn = New-Object System.Data.SqlClient.SqlConnection
$ConnectionString = "Data Source=desktop-ub0lhnh;Initial Catalog=project;Integrated Security=True;"
$conn.ConnectionSTring = $ConnectionString
$conn.Open()

$cmd = New-Object System.Data.SqlClient.SqlCommand($expiringSeedscheck, $conn)
$cmd.CommandTimeout=$querytimeout


##execute query, read result
$ds = New-Object System.Data.DataSet
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
[void]$da.fill($ds)


$result2 = $ds.Tables

$tables = $result2

$conn.close()
$ds = ""
$da = ""


if ($result2 = "") {
    Write-Output "There's no batches expiring in the upcoming year"
} else {
   $Body = "Dear Systems Administrator, please see the following report of batches expiring in the upcoming year." + $result1 + "Sent via Systems Managment System"
    clear-content .\ExpiringSeeds.csv
    foreach ($table in $tables) {
        $table | out-file ExpiringSeeds.csv
        $table
     }
    $path = "C:\Users\Vanessa\Desktop\GitHub\INFO2413\ExpiringSeeds.csv"
    $path
    $smtpmessage = new-object System.Net.Mail.MailMessage($from,$to,$subject,$body)
    $attachment = New-Object System.Net.Mail.Attachment($path)
    $SMTPMessage.Attachments.Add($attachment)
     $SMTPClient = new-object Net.Mail.SMTPClient($smtpserver, $port)
     $SMTPClient.enablessl = $true
     $SMTPClient.Credentials = New-Object System.Net.NetworkCredential("samplefarmseedsco@gmail.com", "nqlgvacxneplndbt"); 
     $smtpclient.send($smtpmessage)
}

########################################################################################################################
WRITE-OUTPUT "QUERY NUMBER THREE"
$conn = New-Object System.Data.SqlClient.SqlConnection
$ConnectionString = "Data Source=desktop-ub0lhnh;Initial Catalog=project;Integrated Security=True;"
$conn.ConnectionSTring = $ConnectionString
$conn.Open()

$cmd = New-Object System.Data.SqlClient.SqlCommand($wastedSeedsCheck, $conn)
$cmd.CommandTimeout=$querytimeout


##execute query, read result
$ds = New-Object System.Data.DataSet
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
[void]$da.fill($ds)


$result3 = $ds.Tables

$result3

$conn.close()
$ds = ""
$da = ""

if ($result3 = "") {
   
} else {
        $Body = "Dear Systems Administrator, the following seeds are to be wasted promptly. They are past their expiry." + $result1 + "Sent via Systems Managment System"
    clear-content .\WastedBatches.csv
    foreach ($table in $tables) {
        $table | out-file WastedBatches.csv
        $table
     }
    $path = "C:\Users\Vanessa\Desktop\GitHub\INFO2413\WastedBatches.csv"
    $path
    $smtpmessage = new-object System.Net.Mail.MailMessage($from,$to,$subject,$body)
    $attachment = New-Object System.Net.Mail.Attachment($path)
    $SMTPMessage.Attachments.Add($attachment)
     $SMTPClient = new-object Net.Mail.SMTPClient($smtpserver, $port)
     $SMTPClient.enablessl = $true
     $SMTPClient.Credentials = New-Object System.Net.NetworkCredential("samplefarmseedsco@gmail.com", "nqlgvacxneplndbt"); 
     $smtpclient.send($smtpmessage)
}




## run script once a day automatically to check on tables
Start-Sleep -Seconds 86400