using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace BookStore.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    author = table.Column<string>(unicode: false, maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    title = table.Column<string>(unicode: false, maxLength: 500, nullable: true, defaultValueSql: "'NULL'"),
                    description = table.Column<string>(unicode: false, maxLength: 1000, nullable: true, defaultValueSql: "'NULL'"),
                    price = table.Column<float>(nullable: false, defaultValue: 0),
                    discountedPrice = table.Column<float>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(unicode: false, maxLength: 200, nullable: true, defaultValueSql: "'NULL'"),
                    Parentid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categorybook",
                columns: table => new
                {
                    bookId = table.Column<int>(type: "int(11)", nullable: false),
                    categoryId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.bookId, x.categoryId });
                    table.ForeignKey(
                        name: "FK_CategoryBook_Book",
                        column: x => x.bookId,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryBook_Category",
                        column: x => x.categoryId,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "FK_CategoryBook_Category",
                table: "categorybook",
                column: "categoryId");

            migrationBuilder.InsertData("book", 
                new []{"id", "author", "title", "description", "price", "discountedPrice"}, 
                new object[,]
                {
                { 1, "velit", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin feugiat massa sit amet auctor vulputate. Quisque fermentum tempor nisl, eget tristique velit imperdiet et. Maecenas tincidunt, elit eget tincidunt ornare, magna lorem dictum turpis, vitae iaculis augue sapien in massa. Sed rhoncus suscipit nisl vitae lacinia. Vestibulum sit amet aliquet odio. In vestibulum iaculis lectus. Mauris et eros eu eros tincidunt rutrum laoreet ut velit. Nulla blandit efficitur arcu, ut porttitor sem posuere nec. Fusce eleifend ligula quis sem gravida congue. Phasellus et urna in purus lobortis suscipit. Praesent ac tempus mi. In a gravida mi.", 103, 98},
                { 2, "euismod", "Etiam a turpis at lacus mattis lacinia.", "Cras vulputate ultrices mauris. Donec eget odio vel urna efficitur sodales. Pellentesque sagittis bibendum neque id rutrum. Nulla at ex fringilla nunc mattis sodales. Duis in lacinia augue. Etiam gravida lobortis urna, in tempor velit. Sed mi dolor, consectetur vel est ut, bibendum fringilla purus.", 144, 139},
                { 3, "in", "Nulla eu orci auctor, vehicula ipsum eget, mattis neque.", "Etiam interdum nec sapien vitae suscipit. Vestibulum sodales ante mi, vel interdum augue ultrices ac. Sed eu molestie lacus. Donec porttitor elementum libero, vitae dapibus leo convallis vitae. Integer pellentesque dui vel quam luctus condimentum. Nam a pulvinar mauris. Vivamus eu condimentum massa.", 48, 41},
                { 4, "pellentesque", "Aliquam ac neque congue risus rhoncus blandit sit amet nec metus.", "Nulla commodo luctus pellentesque. Donec posuere mauris vel consectetur rhoncus. Proin eu lobortis enim, dapibus elementum orci. Nulla vehicula interdum ipsum, nec rhoncus felis sagittis a. Sed porttitor condimentum sem nec ornare. Sed eget imperdiet elit. Duis quis molestie lorem, hendrerit aliquam risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer tempus aliquet sem et eleifend. Nulla sed purus vitae sem pretium suscipit sit amet at orci. Quisque a nisl eu magna auctor lacinia ac ac libero. In vitae tempor ipsum, id cursus felis. Maecenas sapien sapien, auctor ut lorem in, luctus laoreet enim. Integer fermentum turpis enim, at lacinia tortor pharetra sit amet.", 137, 130},
                { 5, "massa", "Quisque eu lorem eleifend ante luctus malesuada quis quis velit.", "Cras dignissim purus in purus rhoncus faucibus. Morbi elementum tincidunt eros eu fringilla. Praesent vel diam id nunc varius hendrerit sed vel diam. Sed eleifend enim eu augue blandit, vel interdum urna ornare. Curabitur quis neque a velit gravida placerat. Ut leo libero, fermentum nec aliquet dictum, fermentum eu elit. Pellentesque cursus lorem ultricies, cursus turpis vel, pretium augue. Duis egestas neque id sollicitudin ultrices. Etiam eu tortor libero. Praesent vehicula at ante in aliquam. Maecenas arcu nisl, placerat sit amet ultricies eu, iaculis id nunc. Etiam non lectus ullamcorper ligula porttitor ullamcorper. Pellentesque vel lacus vitae nibh tempor imperdiet. Nulla auctor lectus orci, quis scelerisque libero condimentum eu.", 123, 115},
                { 6, "placerat", "Aliquam ultricies odio sagittis, molestie orci id, accumsan purus.", "Nam vulputate mattis magna id tempor. Pellentesque eu nisi erat. Fusce quis purus quis enim ullamcorper tempus sed a quam. Suspendisse vel gravida nibh. Integer quis scelerisque arcu. Maecenas sit amet nisi nisi. Integer volutpat iaculis quam, at imperdiet diam vehicula eget. Curabitur non dignissim ipsum. Nullam tincidunt diam quis purus placerat vehicula. Maecenas ultricies purus elit, non accumsan dolor congue sed. Nunc quis diam massa. Aliquam maximus sed nisi non consequat. Phasellus rutrum mi leo, ac scelerisque nunc facilisis imperdiet. Mauris tincidunt feugiat nulla.", 23, 18},
                { 7, "duis", "Pellentesque elementum nunc commodo urna scelerisque mollis.", "Fusce semper urna ac urna fringilla dapibus. Nulla felis nisi, cursus at luctus non, dapibus id augue. Proin mollis enim in purus iaculis dignissim. In id pharetra nisi, ut vulputate felis. Nullam semper faucibus finibus. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nam ultricies ac turpis eleifend interdum. In elit sapien, convallis laoreet nibh vel, dapibus egestas justo. Etiam at nulla id quam semper scelerisque. Nunc egestas, orci at tincidunt facilisis, sem mi molestie turpis, ornare imperdiet urna arcu vel elit.", 177, 170},
                { 8, "ultricies", "Sed condimentum felis ac ex blandit, id ullamcorper quam rutrum.", "Ut consequat mauris a ligula volutpat, et elementum metus vulputate. Nam eleifend faucibus lorem sit amet hendrerit. Suspendisse iaculis, dolor in cursus gravida, eros nibh ullamcorper erat, aliquam lacinia nisl metus eget magna. Morbi tempus, purus ut interdum elementum, dolor tortor aliquam erat, vitae tempor augue nisl sit amet orci. Cras feugiat ante aliquam dignissim tincidunt. Phasellus id iaculis elit. Nam neque velit, rhoncus et quam quis, consequat interdum sapien. Sed blandit risus condimentum lacus luctus, sit amet egestas arcu volutpat. In a nisl vel mi viverra rhoncus. Integer ut erat ut diam elementum eleifend.", 118, 109},
                { 9, "lacus", "Mauris auctor justo eget pellentesque mollis.", "Sed sollicitudin erat id odio tincidunt maximus. Curabitur in tellus sit amet turpis tempus malesuada non ac lectus. Vivamus non feugiat enim, non commodo lectus. Maecenas porta, nisi id fringilla placerat, massa tellus euismod arcu, non maximus tortor sem a erat. Aenean nec nibh molestie, venenatis odio porttitor, mollis est. Curabitur in luctus lacus. Morbi consectetur molestie interdum. In hac habitasse platea dictumst. Quisque feugiat, velit id commodo ultricies, felis dui ultrices purus, quis dignissim ipsum urna id elit. Morbi convallis nisi ac nisi mattis auctor. Aliquam erat volutpat. Vestibulum accumsan tristique lacinia. Ut eget cursus enim, a tempus erat.", 174, 165},
                { 10, "sed", "Proin laoreet felis vel ipsum consectetur iaculis.", "Nulla sit amet eros tellus. Suspendisse potenti. Praesent vitae eros ipsum. Sed maximus malesuada nunc at volutpat. Sed semper quis mauris vitae ullamcorper. Nullam commodo, erat vel tristique fringilla, orci lectus auctor felis, eu fringilla tellus justo in nisl. Maecenas sodales convallis cursus. Fusce tempus volutpat convallis. Proin suscipit semper sem, et venenatis quam auctor ac. Integer sit amet scelerisque arcu. Nullam finibus felis quis augue cursus tempor. Suspendisse egestas mi sed nulla hendrerit, eget pretium turpis laoreet. Fusce quam tellus, lacinia non dapibus sed, eleifend at purus.", 102, 93},
                { 11, "turpis", "Vestibulum ultricies sem at urna luctus, non pretium diam semper.", "Nam pellentesque magna in venenatis ullamcorper. Integer justo sapien, molestie at condimentum sit amet, dapibus sit amet mi. Duis vel aliquam nunc. Donec pulvinar nibh in venenatis hendrerit. Nulla non sollicitudin mi, in cursus ipsum. Cras eget turpis ac arcu lacinia condimentum sit amet id elit. Aenean lobortis metus vel nunc tincidunt, ut tempor felis convallis. Nunc eget suscipit mi, pellentesque malesuada dui. Praesent sagittis facilisis odio at placerat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin diam urna, tempus at lacus id, interdum placerat nisl. Nam et erat vitae dui blandit imperdiet et tincidunt dolor.", 97, 91},
                { 12, "tincidunt", "In nec velit sagittis, commodo risus sit amet, sollicitudin felis.", "Fusce pulvinar ac erat non ornare. Vestibulum dignissim lacus eu urna rutrum mattis. Etiam consectetur velit id nisi blandit, in facilisis nulla vestibulum. Fusce quis laoreet ante. Pellentesque ullamcorper luctus venenatis. Quisque sed est eleifend, pulvinar mauris sit amet, tempor nunc. Mauris cursus, nulla eu tincidunt ultrices, ante eros placerat neque, a sollicitudin nunc sem eu risus. Pellentesque dapibus felis quis sapien volutpat luctus. Aenean sed nibh consequat, efficitur tortor at, cursus lorem. Nullam interdum est eget porttitor ultricies. Vestibulum hendrerit lorem tristique arcu consectetur gravida. Mauris elementum, urna in dapibus posuere, mi lorem tristique ipsum, ut tincidunt orci tellus sed ante. Pellentesque orci risus, rutrum at condimentum eu, aliquam at ex. In vel tempus nisi. Suspendisse pretium, dui eget bibendum euismod, lorem ante elementum arcu, vitae placerat nulla mauris nec lacus. Nam pellentesque enim neque, in iaculis ipsum feugiat et.", 67, 57},
                { 13, "id", "Vestibulum vitae turpis sed turpis vehicula pellentesque non sed nisi.", "Donec feugiat vitae velit a volutpat. Morbi luctus vulputate ipsum ut tincidunt. Praesent ut mattis elit. Vivamus luctus at nisi eu fringilla. Proin eget bibendum mauris. Ut vel tempor nisl, at finibus neque. Vivamus pellentesque ipsum arcu, sed malesuada risus suscipit dapibus. Ut imperdiet justo lacus, a semper velit euismod ac. Proin eu velit vitae tortor pulvinar vestibulum. Phasellus ut consequat dolor, nec porta purus. Nam vitae pharetra odio. Duis eu lectus tincidunt turpis egestas venenatis.", 138, 129},
                { 14, "aliquet", "Donec et metus nec nulla tempus bibendum sit amet eu dui.", "Nam rutrum, velit ac feugiat aliquam, nisl risus lacinia tortor, a cursus eros diam sit amet est. Nam sit amet auctor erat. Nulla vestibulum est eu elementum accumsan. Vestibulum lobortis porta enim nec porttitor. Aenean in sapien lorem. Etiam vel pretium nunc. Quisque eleifend leo nec tortor tincidunt, eu tincidunt lorem consectetur. Nulla eget nisl et eros auctor imperdiet. Cras varius dignissim aliquet. Mauris vel purus sed massa porta vehicula at eget nulla. Fusce efficitur dui nec eros luctus vestibulum.", 130, 125},
                { 15, "risus", "Nunc sit amet dolor efficitur, aliquam sapien ac, condimentum elit.", "Aliquam bibendum rhoncus ipsum, at fermentum tellus euismod id. Fusce et tristique neque. Vivamus cursus ipsum non maximus semper. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. In nulla sem, pharetra vitae volutpat non, fringilla quis libero. Quisque mollis rhoncus ornare. Sed lacinia diam et auctor posuere. Suspendisse tellus orci, fermentum nec nisi vitae, aliquet posuere lacus. Quisque venenatis mauris ante. Aliquam scelerisque a metus ut tristique. Aliquam eu lorem consequat elit interdum semper. Proin sit amet ligula nec diam pulvinar sodales sit amet sit amet ligula. Duis eu mauris laoreet, rutrum ipsum at, rhoncus libero. Vestibulum convallis euismod nibh. Maecenas sodales massa sed bibendum molestie.", 131, 124},
                { 16, "feugiat", "Morbi sit amet elit ut sapien porttitor aliquet venenatis nec metus.", "Vivamus nisi risus, faucibus id arcu sed, varius volutpat nibh. Nam non massa sed neque euismod auctor. Duis gravida erat vitae lectus rhoncus, nec dictum lorem consectetur. Donec vitae gravida quam, nec porta eros. Morbi ultrices massa arcu, a pulvinar ante vulputate quis. Aliquam vel auctor ipsum. Vivamus dictum felis in turpis rhoncus, id porttitor lacus hendrerit. Vestibulum sed quam nulla. Donec tempus, neque ullamcorper euismod sollicitudin, velit dui tempus elit, a porta ligula ex ac quam.", 77, 67},
                { 17, "in", "Vestibulum id felis egestas, accumsan tellus hendrerit, fringilla tellus.", "Etiam congue dolor in lobortis varius. Curabitur ligula dui, tincidunt nec laoreet quis, condimentum id mauris. Etiam dictum enim quis ex vestibulum cursus. Curabitur cursus purus eu magna bibendum, et efficitur nisl volutpat. Quisque venenatis egestas justo ut dapibus. Vivamus et eros aliquam, dignissim mi sed, blandit risus. Fusce tincidunt, eros feugiat mollis pretium, enim leo mollis ante, eu accumsan velit felis eget neque. Ut volutpat, velit a fringilla tempus, nunc nibh accumsan tortor, eget mattis lorem purus eget ex. Praesent vitae scelerisque justo. Nullam consequat sapien ligula, et efficitur libero scelerisque non.", 117, 108},
                { 18, "ante", "Quisque vestibulum velit congue fermentum hendrerit.", "Sed molestie orci in molestie commodo. Fusce aliquet vitae erat vel feugiat. Donec eu arcu quis mauris dignissim efficitur suscipit ac risus. Vivamus massa nisi, dapibus sit amet ante et, sollicitudin rhoncus magna. Nam finibus ligula vitae lectus venenatis hendrerit. Etiam nec consequat est, vel ornare dui. Sed nec consequat dui. Proin euismod, quam sed imperdiet consectetur, justo neque fermentum dui, eu vestibulum quam justo aliquam est. Aliquam aliquam risus at arcu elementum pulvinar. Nunc a ornare diam, vitae egestas leo. Nullam semper eros at elit iaculis, vitae luctus eros convallis. Etiam sit amet leo malesuada, sagittis elit non, dapibus erat. Nulla bibendum molestie nisi, sed cursus ex suscipit ac. Duis elit erat, congue at eros non, tempus pulvinar ipsum.", 90, 80},
                { 19, "metus", "Ut mattis mi eget pellentesque vulputate.", "Donec aliquam facilisis dolor, et sollicitudin sapien convallis a. Mauris dignissim venenatis dui, vel scelerisque turpis dictum ut. Nunc tincidunt vulputate dolor, ac laoreet diam accumsan id. In nec finibus purus, sit amet ultricies nisl. Donec pharetra dui volutpat felis pretium, vel ornare massa placerat. In finibus, justo a euismod ultrices, ligula tortor ullamcorper nibh, id semper turpis justo vitae augue. Pellentesque ut scelerisque nisl. Quisque sem tellus, sagittis non ex non, tincidunt molestie purus. Ut congue faucibus mi sit amet semper. Duis non tempor neque. Vivamus eleifend nulla tortor, vitae consequat nibh sagittis ut. Mauris sit amet sapien ut purus ullamcorper maximus eu elementum turpis.", 114, 107},
                { 20, "dictum", "Praesent quis metus maximus, malesuada mauris non, bibendum lorem.", "Quisque venenatis sem at velit posuere, eu imperdiet lorem ornare. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed id ex ut mi luctus aliquet eu eget nulla. In id mollis mi. Phasellus semper vestibulum massa. Nunc metus tellus, porta eu ullamcorper vel, hendrerit at dui. Nulla ac felis id neque sodales facilisis. In dictum purus in nisl pretium, quis pretium justo volutpat. Quisque varius cursus ex sit amet iaculis. Ut ut hendrerit odio. Vivamus ut sem vitae ante auctor mollis. Phasellus maximus justo id dui tincidunt, non mollis augue finibus. Suspendisse potenti. Integer condimentum malesuada nibh nec efficitur. Ut ac pulvinar dui.", 175, 165},
                { 21, "at", "Duis interdum purus non convallis fermentum.", "Vivamus purus neque, tempus imperdiet iaculis et, congue in enim. Etiam luctus auctor turpis, vitae aliquet arcu tempus non. Mauris eu dictum ex. Nunc at magna eget ex porta volutpat in sed velit. Duis in venenatis ex, ut scelerisque metus. Suspendisse suscipit orci viverra vestibulum congue. Curabitur tempus pulvinar metus, rutrum semper est semper sed. Nam quis magna a turpis sodales blandit ac eu erat. Mauris ut quam odio.", 58, 51},
                { 22, "tempor", "Nam non risus et elit feugiat tempor at vel tortor.", "Suspendisse bibendum odio in nisi placerat, eu cursus neque egestas. Nulla sed posuere neque. Vestibulum ac laoreet nibh, quis tristique elit. Nam rhoncus aliquet nibh, sed porttitor nunc interdum ut. Etiam rutrum augue sed magna convallis sollicitudin. Cras feugiat posuere enim a posuere. Etiam sollicitudin metus fringilla ex semper, a hendrerit leo aliquet. Cras vitae hendrerit nulla, ut efficitur nisl. Donec sit amet accumsan ante. Vestibulum ultricies a nulla sit amet dignissim. Curabitur quis sem sit amet magna scelerisque porttitor porttitor in neque.", 93, 83},
                { 23, "commodo", "Quisque ac sapien mollis, dapibus nunc vel, maximus metus.", "Curabitur tempus ac velit in pellentesque. Maecenas eu volutpat orci. Nulla tempor porttitor arcu, et congue tellus efficitur eu. Vivamus dapibus, nibh non facilisis cursus, nibh diam convallis nibh, sed consectetur elit arcu at neque. Donec facilisis mi ac justo bibendum, quis gravida sem blandit. Cras ut justo dapibus, maximus leo ac, venenatis ex. Curabitur cursus justo risus, interdum sollicitudin metus sagittis porttitor. Proin placerat sapien non ullamcorper varius. Vestibulum efficitur magna in blandit semper. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vestibulum congue lacus eget enim mollis, sed ultricies lorem vulputate. In mauris massa, dignissim non est vulputate, accumsan convallis metus. Nunc interdum odio ut arcu feugiat condimentum. Maecenas eget fringilla turpis, nec faucibus mauris. Pellentesque eget urna efficitur, posuere tellus vitae, pulvinar lacus. Nulla vitae lorem a risus mattis semper eget sed metus.", 159, 154},
                { 24, "ullamcorper", "Cras pellentesque arcu id pretium rutrum.", "Suspendisse quis ante rutrum, tincidunt leo quis, tincidunt est. Pellentesque venenatis tellus quis nisi mollis dapibus. Phasellus quis nunc iaculis, viverra neque vel, auctor felis. Donec eros lectus, porta id interdum nec, vulputate eu urna. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Etiam placerat justo neque, id vestibulum dui suscipit in. Quisque sit amet dui in sapien aliquam lacinia dignissim vitae magna. Morbi eleifend aliquet imperdiet. Vestibulum pretium, magna ac gravida vestibulum, eros ante accumsan tellus, ac porta massa velit et mi. Suspendisse non accumsan massa. Integer ac tortor imperdiet, malesuada orci ac, varius dolor.", 43, 37},
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categorybook");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
