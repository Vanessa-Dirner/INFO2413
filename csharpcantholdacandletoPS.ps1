




############# queries
$seedQuantityCheck = "use project;SELECT batch FROM inventory WHERE quantity < 500;"
$wastedSeedsCheck = "use project;SELECT * FROM inventory WHERE expirationdate < getdate();"
#$expiringSeedscheck = "use project;SELECT* FROM inventory WHERE expirationdate >= dateadd(year, +1, getdate());"

## email

$subject = "Vegetable Seed Managment System"
$body = "Dear Systems Administrator, please see the following report.   Sent via Systems Managment System"
$to = "samplefarmseedsco@gmail.com" 
$from = "samplefarmseedsco@gmail.com"   
$SmtpServer = 'smtp.gmail.com' 
$Port = 587 

####################
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
#    $Body = "Dear Systems Administrator, please see the following report." + $result1 + "Sent via Systems Managment System"
    clear-content .\output.csv
    foreach ($table in $tables) {
       $table | out-file output.csv
       $table
    }
    $path = "C:\Users\Vanessa\Desktop\GitHub\INFO2413\output.csv"
    $path
    $smtpmessage = new-object System.Net.Mail.MailMessage($from,$to,$subject,$body)
    $attachment = New-Object System.Net.Mail.Attachment($path)
    $SMTPMessage.Attachments.Add($attachment)
     $SMTPClient = new-object Net.Mail.SMTPClient($smtpserver, $port)
     $SMTPClient.enablessl = $true
     $SMTPClient.Credentials = New-Object System.Net.NetworkCredential("samplefarmseedsco@gmail.com", "nqlgvacxneplndbt"); 
     $smtpclient.send($smtpmessage)
}

$conn.close()
$ds = ""
$da = ""
##Write-Output "SECOND QUERY"
###############
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


$result2 = $ds.Tables

#$result2

$conn.close()
$ds = ""
$da = ""

